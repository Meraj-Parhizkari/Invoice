using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.Invoice;
using InvoiceSystem.Services.Contracts.InvoiceSystem;
using InvoiceSystem.ViewModels.InvoiceSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.InvoiceSystem
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _uow;
        private DbSet<Product> _product;

        public ProductService(
            IUnitOfWork uow
            )
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _product = uow.Set<Product>();
        }

        public async Task<Product> Create(Product product)
        {
            _product.Add(product);
            await _uow.SaveChangesAsync();
            return product;

        }

        //public void Update(Product product)
        //{
        //    _product.Update(product);
        //    _uow.SaveChangesAsync();
        //}
        public void Update(Product product, int userId)
        {
            var pd = _product.FirstOrDefault(x => x.CreatedByUserId == userId && x.Id == product.Id);

            if (pd != null)
            {
                pd.ProductName = product.ProductName;
                pd.ProductCategoryId = product.ProductCategoryId;
                pd.ProductCode = product.ProductCode;
                _product.Update(pd);
                _uow.SaveChangesAsync();
            }

        }
        public async Task<Product> FindAsync(int id, int userId)
        {
            return await _product.FirstOrDefaultAsync(x => x.CreatedByUserId == userId && x.Id == id);
        }

        public async Task<List<Product>> GetAll(int userId)
        {
            //return await _product.Include(x => x.ProductCategory).ToListAsync();
            return await _product.Where(x => x.CreatedByUserId == userId).ToListAsync();
            //return await _product.ToListAsync();
        }

        public void Remove(Product product,int userId)
        {
            if(_product.Any(x=>x.CreatedByUserId==userId&& x.Id == product.Id)) { 
            _product.Remove(product);
            _uow.SaveChangesAsync();
            }
        }

        public Task<List<Product>> GetProductByProductCategoryId(int id)
        {
            return _product.Where(x => x.ProductCategoryId == id).ToListAsync();
        }
    }
}
