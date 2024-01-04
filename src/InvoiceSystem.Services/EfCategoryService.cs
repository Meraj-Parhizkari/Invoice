using Microsoft.EntityFrameworkCore;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities;
using InvoiceSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.Services
{
    public class EfCategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Category> _categories;

        public EfCategoryService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));

            _categories = _uow.Set<Category>();
        }

        public void AddNewCategory(Category category)
        {
            _categories.Add(category);
        }

        public IList<Category> GetAllCategories()
        {
            return _categories.ToList();
        }
    }
}