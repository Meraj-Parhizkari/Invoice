using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using InvoiceSystem.DataLayer.MSSQL;
using InvoiceSystem.Services.Identity;
using InvoiceSystem.ViewModels.Identity.Settings;
using System;

namespace InvoiceSystem.IocConfig
{
    public static class CustomTicketStoreExtensions
    {
        public static IServiceCollection AddCustomTicketStore(
            this IServiceCollection services, SiteSettings siteSettings)
        {
            // To manage large identity cookies
            var cookieOptions = siteSettings.CookieOptions;
            if (!cookieOptions.UseDistributedCacheTicketStore)
            {
                return services;
            }

            switch (siteSettings.ActiveDatabase)
            {
                case ActiveDatabase.InMemoryDatabase:
                    services.AddMemoryCache();
                    services.AddScoped<ITicketStore, MemoryCacheTicketStore>();
                    break;

                case ActiveDatabase.LocalDb:
                case ActiveDatabase.SqlServer:
                    services.AddDistributedSqlServerCache(options =>
                    {
                        var cacheOptions = cookieOptions.DistributedSqlServerCacheOptions;
                        options.ConnectionString = string.IsNullOrWhiteSpace(cacheOptions.ConnectionString) ?
                                siteSettings.GetMsSqlDbConnectionString() :
                                cacheOptions.ConnectionString;
                        options.SchemaName = cacheOptions.SchemaName;
                        options.TableName = cacheOptions.TableName;
                    });
                    services.AddScoped<ITicketStore, DistributedCacheTicketStore>();
                    break;

                case ActiveDatabase.SQLite: //TODO:
                    services.AddMemoryCache();
                    services.AddScoped<ITicketStore, MemoryCacheTicketStore>();
                    break;

                default:
                    throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file.");
            }

            return services;
        }
    }
}