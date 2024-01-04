using InvoiceSystem.Entities;
using System.Collections.Generic;

namespace InvoiceSystem.Services.Contracts
{
    public interface IProductService
    {
        void AddNewProduct(Product product);
        IList<Product> GetAllProducts();
    }
}