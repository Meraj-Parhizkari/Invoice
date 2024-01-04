using Microsoft.EntityFrameworkCore;
using InvoiceSystem.DataLayer.Context;

namespace InvoiceSystem.DataLayer.InMemoryDatabase
{
    public class InMemoryDatabaseContext : ApplicationDbContext
    {
        public InMemoryDatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}