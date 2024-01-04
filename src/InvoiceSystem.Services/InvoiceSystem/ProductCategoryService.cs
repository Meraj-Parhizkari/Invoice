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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _uow;
        
        private readonly DbSet<ProductCategory> _productCategory;
        public ProductCategoryService(
            IUnitOfWork uow
            )
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _productCategory = uow.Set<ProductCategory>();
        }

        public async Task<ProductCategory> Create(ProductCategory productCategory)
        {
             _productCategory.Add(productCategory);
            await _uow.SaveChangesAsync();
            return productCategory;
        }

        public void Update(ProductCategory productCategory,int userId)
        {


            var pCategory = _productCategory.FirstOrDefault(x => x.CreatedByUserId == userId && x.Id == productCategory.Id);

            if (pCategory != null)
            {
                pCategory.Name = productCategory.Name;
                productCategory.ParentId = productCategory.ParentId;
                _productCategory.Update(pCategory);
                _uow.SaveChangesAsync();
            }
            

        }

        public async Task<List<ProductCategory>> GetAll(int userId)
        {
            
            return await _productCategory.Where(x=>x.CreatedByUserId == userId) .ToListAsync();
        }

        public async Task<ProductCategory> FindAsync(int id,int userId)
        {
            return await _productCategory.FirstOrDefaultAsync(x => x.CreatedByUserId == userId && x.Id == id);

        }

        public void Remove(ProductCategory productCategory,int userId)
        {
            if (_productCategory.Any(x => x.CreatedByUserId == userId && x.Id == productCategory.Id))
            {
            _productCategory.Remove(productCategory);
            _uow.SaveChangesAsync();
            }
        }
    }
}
