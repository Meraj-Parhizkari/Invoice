using InvoiceSystem.Entities;
using InvoiceSystem.Entities.Cars;
using InvoiceSystem.ViewModels.App;
using InvoiceSystem.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Services.Contracts.Cars
{
    public interface ICarService
    {
        Task CreateAsync(CarViewModel model);
        Task<bool> EditAsync(CarViewModel model);
        Task<List<Car>> GetAllAsync(int? createdUserId = null);
        Task<List<Car>> Get_TakeCount_Async(int takeCount = 10, CarStatusEnum adStatus = CarStatusEnum.Confirmed);
        IQueryable<Car> GetAllIQuerable(AdvancedSearchCarViewModel viewModel, CarStatusEnum adStatus = CarStatusEnum.Confirmed, int? createdUserId = null);
        Task<Car> FindByIdAsync(int id);
        Task<bool> RemoveImageBy_CarImageId_Or_filename_Async(int? adImageId, string filename);
        Task<bool> AddImageAsync(CarImage adImage, CarStatusEnum? adStatus = null);
        Task<bool> ChangeCarStatusAsync(int id, CarStatusEnum adStatus);
        Task<List<Car>> HomePageSearchAsync(HomePageSearchCarViewModel viewModel, int? takeRecordCount = 20);
        Task<(decimal? minCarPrice, decimal? maxCarPrice)> GetMaxMin_CarPriceAsync();
    }
}
