using InvoiceSystem.Entities.Invoice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.InvoiceSystem
{
    public  interface IProductService
    {
        Task<Product> FindAsync(int id,int userId);
        Task<List<Product>> GetAll(int userId);
        Task<Product> Create(Product product);
        void Update(Product product,int userId);
        void Remove(Product product,int userId);

        Task<List<Product>> GetProductByProductCategoryId(int id);


    }

}
