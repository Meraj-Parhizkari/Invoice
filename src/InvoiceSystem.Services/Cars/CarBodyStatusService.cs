using AutoMapper;
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
    public class CarBodyStatusService : ICarBodyStatusService
    {
        #region Properties
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<CarBodyStatus> _carBodyStatuses;
        #endregion

        #region ctor
        public CarBodyStatusService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            this._uow = unitOfWork;
            this._carBodyStatuses = this._uow.Set<CarBodyStatus>();

            this._contextAccessor = contextAccessor;
            this._contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));
        }
        #endregion


        #region GetAllAsync
        public async Task<List<CarBodyStatus>> GetAllAsync()
        {
            var carBodyStatuses = await _carBodyStatuses
                .ToListAsync();

            return carBodyStatuses;
        }
        #endregion
    }
}
