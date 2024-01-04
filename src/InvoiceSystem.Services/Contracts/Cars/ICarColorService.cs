using InvoiceSystem.Entities.Cars;
using InvoiceSystem.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Services.Contracts.Cars
{
    public interface ICarColorService
    {
        Task Create(CarColorViewModel model);
        Task Edit(CarColorViewModel carColor);
        Task<List<CarColor>> GetAll();
        Task<CarColor> GetById(int Id);
        Task<List<CarColor>> GetAllByColorTypeAsync(ColorTypeEnum colorType);
    }
}
