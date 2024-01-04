using InvoiceSystem.Entities.Invoice;
using InvoiceSystem.ViewModels.InvoiceSystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.InvoiceSystem
{
    public interface IProductCategoryService
    {
        Task<ProductCategory> FindAsync(int id,int userId);
        Task<List<ProductCategory>> GetAll(int userId);
        Task<ProductCategory> Create(ProductCategory productCategory);
        void Update(ProductCategory productCategory,int userId);
        void Remove(ProductCategory productCategory,int userId);
    }
}
