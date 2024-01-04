using InvoiceSystem.Entities;
using InvoiceSystem.Entities.Cars;
using InvoiceSystem.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.Cars
{
    public interface ICarFService
    {
        Task<List<BaseCar>> GetAllByParentIdAsync(int? parentId=null);
        Task<List<BaseCar>> GetAllBrandsAsync();
        Task<List<BaseCar>> GetModelsAsync(int brandId);
        Task<List<BaseCar>> GetTipsAsync(int modelId);
        Task<BaseCar> FindByIdAsync(int id);
        Task<bool> EditAsync(BaseCarViewModel viewModel);
    }
}
