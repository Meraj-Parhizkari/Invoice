//using AutoMapper;
using InvoiceSystem.Common.GuardToolkit;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities;
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
    public class CarFService : ICarFService
    {
        #region Properties
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<BaseCar> _carFs;
        #endregion

        #region ctor
        public CarFService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            this._uow = unitOfWork;
            this._carFs = this._uow.Set<BaseCar>();

            this._contextAccessor = contextAccessor;
            this._contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));
        }
        #endregion

        #region FindByType
        public async Task<List<BaseCar>> GetAllBrandsAsync()
        {
            var carFs = await _carFs
                .Where(x => x.CarFType == CarFTypeEnum.Brand)
                .ToListAsync();

            return carFs;
        }

        #region GetAllByParentIdAsync
        public async Task<List<BaseCar>> GetAllByParentIdAsync(int? parentId = null)
        {
            var carFs = await _carFs
                .Include(x=>x.Children)
                .Include(x=>x.Parent)
                .Where(x => x.ParentId == parentId)
                .ToListAsync();

            return carFs;
        }
        #endregion


        public async Task<List<BaseCar>> GetModelsAsync(int brandId)
        {
            var carFs = await _carFs
                            .Where(x => x.ParentId == brandId)
                            .ToListAsync();

            return carFs;
        }

        public async Task<List<BaseCar>> GetTipsAsync(int modelId)
        {
            var carFs = await _carFs
                            .Where(x => x.ParentId == modelId)
                            .ToListAsync();

            return carFs;
        }
        #endregion

        #region FindByIdAsync
        public async Task<BaseCar> FindByIdAsync(int id)
        {
            var carF = await _carFs
                .Include(x=>x.Parent.Parent)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return carF;
        }
        #endregion

        #region EditAsync
        public async Task<bool> EditAsync(BaseCarViewModel viewModel)
        {
            var carF = await _carFs
                            .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            
            carF.Name = viewModel.Name;

            var result = await _uow.SaveChangesAsync();

            return result>=0;
        }
        #endregion


    }
}
