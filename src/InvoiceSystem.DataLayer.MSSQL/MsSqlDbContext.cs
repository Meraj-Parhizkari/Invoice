using Microsoft.EntityFrameworkCore;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.App;

namespace InvoiceSystem.DataLayer.MSSQL
{
    public class MsSqlDbContext : ApplicationDbContext
    {
        public MsSqlDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}