using InvoiceSystem.Entities;
using InvoiceSystem.Entities.Cars;
using InvoiceSystem.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.Cars
{
    public interface ICarBodyStatusService
    {
        Task<List<CarBodyStatus>> GetAllAsync();        
    }
}
