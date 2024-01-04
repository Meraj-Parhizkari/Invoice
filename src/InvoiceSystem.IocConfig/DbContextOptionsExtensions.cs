using Microsoft.Extensions.DependencyInjection;
using InvoiceSystem.DataLayer.InMemoryDatabase;
using InvoiceSystem.DataLayer.MSSQL;
using InvoiceSystem.DataLayer.SQLite;
using InvoiceSystem.Services.Contracts.Identity;
using InvoiceSystem.ViewModels.Identity.Settings;
using System;

namespace InvoiceSystem.IocConfig
{
    public static class DbContextOptionsExtensions
    {
        public static IServiceCollection AddConfiguredDbContext(
            this IServiceCollection serviceCollection, SiteSettings siteSettings)
        {
            switch (siteSettings.ActiveDatabase)
            {
                case ActiveDatabase.InMemoryDatabase:
                    serviceCollection.AddConfiguredInMemoryDbContext(siteSettings);
                    break;

                case ActiveDatabase.LocalDb:
                case ActiveDatabase.SqlServer:
                    serviceCollection.AddConfiguredMsSqlDbContext(siteSettings);
                    break;

                case ActiveDatabase.SQLite:
                    serviceCollection.AddConfiguredSQLiteDbContext(siteSettings);
                    break;

                default:
                    throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file.");
            }

            return serviceCollection;
        }

        /// <summary>
        /// Creates and seeds the database.
        /// </summary>
        public static void InitializeDb(this IServiceProvider serviceProvider)
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var identityDbInitialize = scope.ServiceProvider.GetRequiredService<IIdentityDbInitializer>();
                identityDbInitialize.Initialize();
                identityDbInitialize.SeedData();
            }
        }
    }
}