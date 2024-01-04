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

namespace InvoiceSystem.Services.Cars
{
    public class CarDocService : ICarDocService
    {
        #region Properties
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<CarDoc> _carDoc;
        #endregion

        #region ctor
        public CarDocService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            this._uow = unitOfWork;
            this._carDoc = this._uow.Set<CarDoc>();

            this._contextAccessor = contextAccessor;
            this._contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));
        }
        #endregion

        #region CRUD Methods
        public async Task Create(CarDocViewModel model)
        {
            var carDoc = new CarDoc
            {
                IsActive = model.IsActive,
                Name = model.Name,
            };

            await _carDoc.AddAsync(carDoc);

            await _uow.SaveChangesAsync();
        }

        public async Task Edit(CarDocViewModel model)
        {
            var carDoc = await _carDoc.FindAsync(model.Id);
            carDoc.Name = model.Name;
            carDoc.IsActive = model.IsActive;

            await _uow.SaveChangesAsync();
        }

        public async Task<List<CarDoc>> GetAll()
        {
            return await _carDoc.ToListAsync();
        }

        public async Task<CarDoc> GetById(int Id)
        {
            var carDoc = await _carDoc.FirstOrDefaultAsync(x => x.Id == Id);

            return carDoc;
        }
        #endregion
    }
}
