using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvoiceSystem.Entities.Identity;
using InvoiceSystem.ViewModels.Identity.Settings;

namespace InvoiceSystem.DataLayer.Mappings
{
    public class AppSqlCacheConfiguration : IEntityTypeConfiguration<AppSqlCache>
    {
        private readonly SiteSettings _siteSettings;

        public AppSqlCacheConfiguration(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }

        public void Configure(EntityTypeBuilder<AppSqlCache> builder)
        {
            // For Microsoft.Extensions.Caching.SqlServer
            var cacheOptions = _siteSettings.CookieOptions.DistributedSqlServerCacheOptions;
            builder.ToTable(cacheOptions.TableName, cacheOptions.SchemaName);
            builder.HasIndex(e => e.ExpiresAtTime).HasName("Index_ExpiresAtTime");
            builder.Property(e => e.Id).HasMaxLength(449);
            builder.Property(e => e.Value).IsRequired();
        }
    }
}