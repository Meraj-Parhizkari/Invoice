using InvoiceSystem.Common.GuardToolkit;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.Cars;
using InvoiceSystem.Services.Contracts.Cars;
using InvoiceSystem.ViewModels.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Services.Cars
{
    public class CarColorService : ICarColorService
    {
        #region Properties
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<CarColor> _carColor;
        #endregion

        #region ctor
        public CarColorService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            this._uow = unitOfWork;
            this._carColor = this._uow.Set<CarColor>();

            this._contextAccessor = contextAccessor;
            this._contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));
        }
        #endregion

        #region CRUD Methods
        public async Task Create(CarColorViewModel model)
        {
            var carColor = new CarColor
            {
                 IsActive= model.IsActive,
                  Name = model.Name,
                   Title = model.Title,
            };
            await _carColor.AddAsync(carColor);

          var result=  await _uow.SaveChangesAsync();
        }
        public async Task Edit(CarColorViewModel model)
        {
            var carColor = _carColor.Find(model.Id);
            
                carColor.IsActive = model.IsActive;
                carColor.Name = model.Name;
                carColor.Title = model.Title;
            
            await _uow.SaveChangesAsync();
        }

        public Task<CarColor> GetById(int Id)
        {
            var carColor = _carColor.FirstOrDefaultAsync(x => x.Id == Id);

            return carColor;
        }
        
        public Task<List<CarColor>> GetAll()
        {
            return _carColor.ToListAsync();
        }
        public Task<List<CarColor>> GetAllByColorTypeAsync(ColorTypeEnum colorType)
        {
            var carColors = _carColor
                .Where(x => x.ColorType == colorType)
                .ToListAsync();
            
                return carColors;
        }
        #endregion
    }
}
