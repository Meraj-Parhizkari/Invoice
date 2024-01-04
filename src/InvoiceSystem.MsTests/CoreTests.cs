﻿using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.Identity;
using InvoiceSystem.IocConfig;
using InvoiceSystem.Services.Contracts.Identity;
using InvoiceSystem.ViewModels.Identity.Settings;
using System;
using System.Linq;

namespace InvoiceSystem.MsTests
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2510
    /// </summary>
    [TestClass]
    public class CoreTests
    {
        private readonly IServiceProvider _serviceProvider;

        public CoreTests()
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddLogging(cfg => cfg.AddConsole().AddDebug());
            services.AddScoped<IWebHostEnvironment, TestHostingEnvironment>();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            services.Configure<SiteSettings>(options => configuration.Bind(options))
                .PostConfigure<SiteSettings>(x => { x.ActiveDatabase = ActiveDatabase.InMemoryDatabase; });
            services.AddSingleton<IConfigurationRoot>(provider => configuration);

            services.AddCustomIdentityServices();
            services.AddDNTCommonWeb();
            services.AddCloudscribePagination();

            var siteSettings = services.GetSiteSettings();
            services.AddConfiguredDbContext(siteSettings);
            _serviceProvider = services.BuildServiceProvider();

            var identityDbInitialize = _serviceProvider.GetRequiredService<IIdentityDbInitializer>();
            identityDbInitialize.Initialize();
            identityDbInitialize.SeedData();
        }

        [TestMethod]
        public void Test_UserAdmin_Exists()
        {
            _serviceProvider.RunScopedService<IUnitOfWork>(context =>
            {
                var users = context.Set<User>();
                Assert.IsTrue(users.Any(x => x.UserName == "Admin"));
            });
        }
    }
}