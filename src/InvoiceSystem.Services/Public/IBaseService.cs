using InvoiceSystem.Entities.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Public
{
    public interface IBaseService
    {
        Task<bool> Remove<TEntity>(TEntity entity) where TEntity : class;
        Task<bool> RemoveAsync<TEntity>(int id) where TEntity : class;
    }
}
