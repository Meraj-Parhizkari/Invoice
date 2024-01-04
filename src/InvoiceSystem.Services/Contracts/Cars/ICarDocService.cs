using InvoiceSystem.Entities.Cars;
using InvoiceSystem.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.Cars
{
    public interface ICarDocService
    {
        Task Create(CarDocViewModel model);
        Task Edit(CarDocViewModel model);
        Task<List<CarDoc>> GetAll();
        Task<CarDoc> GetById(int Id);
    }
}
