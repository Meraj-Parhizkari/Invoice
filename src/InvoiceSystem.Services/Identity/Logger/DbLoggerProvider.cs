﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.AuditableEntity;
using InvoiceSystem.Entities.Identity;
using InvoiceSystem.ViewModels.Identity.Settings;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Identity.Logger
{
    public class LoggerItem
    {
        public AppShadowProperties Props { set; get; }
        public AppLogItem AppLogItem { set; get; }
    }

    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly TimeSpan _interval = TimeSpan.FromSeconds(2);
        private readonly IServiceProvider _serviceProvider;
        private readonly IList<LoggerItem> _currentBatch = new List<LoggerItem>();

        private readonly BlockingCollection<LoggerItem> _messageQueue =
            new BlockingCollection<LoggerItem>(new ConcurrentQueue<LoggerItem>());

        private readonly Task _outputTask;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly IOptions<SiteSettings> _siteSettings;

        public DbLoggerProvider(
            IOptions<SiteSettings> siteSettings,
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            _siteSettings = siteSettings ?? throw new ArgumentNullException(nameof(_siteSettings));
            _outputTask = Task.Run(processLogQueue);
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(this, _serviceProvider, categoryName, _siteSettings);
        }

        public void Dispose()
        {
            stop();
            _messageQueue.Dispose();
            _cancellationTokenSource.Dispose();
        }

        internal void AddLogItem(LoggerItem appLogItem)
        {
            if (!_messageQueue.IsAddingCompleted)
            {
                _messageQueue.Add(appLogItem, _cancellationTokenSource.Token);
            }
        }

        private async Task processLogQueue()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                while (_messageQueue.TryTake(out var message))
                {
                    try
                    {
                        _currentBatch.Add(message);
                    }
                    catch
                    {
                        //cancellation token canceled or CompleteAdding called
                    }
                }

                await saveLogItemsAsync(_currentBatch, _cancellationTokenSource.Token);
                _currentBatch.Clear();

                await Task.Delay(_interval, _cancellationTokenSource.Token);
            }
        }

        private async Task saveLogItemsAsync(IList<LoggerItem> items, CancellationToken cancellationToken)
        {
            try
            {
                if (!items.Any())
                {
                    return;
                }

                // We need a separate context for the logger to call its SaveChanges several times,
                // without using the current request's context and changing its internal state.
                using (var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    using (var context = scope.ServiceProvider.GetRequiredService<IUnitOfWork>())
                    {
                        foreach (var item in items)
                        {
                            var addedEntry = context.Set<AppLogItem>().Add(item.AppLogItem);
                            addedEntry.SetAddedShadowProperties(item.Props);
                        }
                        await context.SaveChangesAsync(cancellationToken);
                    }
                }
            }
            catch
            {
                // don't throw exceptions from logger
            }
        }

        private void stop()
        {
            _cancellationTokenSource.Cancel();
            _messageQueue.CompleteAdding();

            try
            {
                _outputTask.Wait(_interval);
            }
            catch (TaskCanceledException)
            {
            }
            catch (AggregateException ex) when (ex.InnerExceptions.Count == 1 &&
                                                ex.InnerExceptions[0] is TaskCanceledException)
            {
            }
        }
    }
}