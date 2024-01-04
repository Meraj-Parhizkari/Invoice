using Microsoft.EntityFrameworkCore;
using InvoiceSystem.Common.EFCoreToolkit;
using InvoiceSystem.DataLayer.Context;

namespace InvoiceSystem.DataLayer.SQLite
{
    public class SQLiteDbContext : ApplicationDbContext
    {
        public SQLiteDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddDateTimeOffsetConverter();
        }
    }
}