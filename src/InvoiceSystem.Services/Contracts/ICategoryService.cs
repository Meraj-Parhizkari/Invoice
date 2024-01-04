using InvoiceSystem.Entities;
using System.Collections.Generic;

namespace InvoiceSystem.Services.Contracts
{
    public interface ICategoryService
    {
        void AddNewCategory(Category category);
        IList<Category> GetAllCategories();
    }
}