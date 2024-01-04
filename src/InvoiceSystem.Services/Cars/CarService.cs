using AutoMapper;
using InvoiceSystem.Common.GuardToolkit;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.Cars;
using InvoiceSystem.Services.Contracts.Cars;
using InvoiceSystem.ViewModels.App;
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
    public class CarService : ICarService
    {
        #region Properties
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Car> _ads;
        private readonly DbSet<CarImage> _carImages;
        #endregion

        #region ctor
        public CarService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _uow = unitOfWork;
            _ads = _uow.Set<Car>();
            _carImages = _uow.Set<CarImage>();

            _contextAccessor = contextAccessor;
            _contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));
        }
        #endregion

        #region Get_takeCount_Async
        public async Task<List<Car>> Get_TakeCount_Async( int takeCount = 10, CarStatusEnum adStatus = CarStatusEnum.Confirmed)
        {
            var iqueryable = _ads
                .Include(x => x.CarBrand)
                .Include(x => x.CarModel)
                .Include(x => x.CarType)
                .Include(x => x.BodyCarColor)
                .Include(x => x.CarBodyStatus)
                .Include(x => x.InsideCarColor)
                .Include(x=>x.CarImages)
                .Include(x=>x.CreatedByUser)
                .AsQueryable()
                .Where(x=>x.CarStatus == adStatus);

            var ads = await iqueryable
                    .OrderByDescending(x => x.ModifiedDateTime)
                    .Take(takeCount)
                    .ToListAsync();

            return ads;
        }
        #endregion
        #region GetAllAsync
        public async Task<List<Car>> GetAllAsync(int? createdUserId = null)
        {
            var iqueryable = _ads
                .Include(x => x.CarBrand)
                .Include(x => x.CarModel)
                .Include(x => x.CarType)
                .Include(x => x.BodyCarColor)
                .Include(x => x.CarBodyStatus)
                .Include(x => x.InsideCarColor)
                .Include(x=>x.CarImages)
                .Include(x=>x.CreatedByUser)
                .AsQueryable();

            if (createdUserId.HasValue)
            {
                iqueryable = iqueryable.Where(x => x.CreatedByUserId == createdUserId);
            }

            var ads = await iqueryable
                .OrderByDescending(x=>x.ModifiedDateTime)
                .OrderByDescending(x=>x.CreatedDateTime)
                .ToListAsync();

            return ads;
        }
        #endregion

        #region GetAllIQuerable
        public IQueryable<Car> GetAllIQuerable(AdvancedSearchCarViewModel viewModel, CarStatusEnum adStatus = CarStatusEnum.Confirmed, int? createdUserId = null)
        {
            var iqueryable = _ads
                .Include(x => x.CarBrand)
                .Include(x => x.CarModel)
                .Include(x => x.CarType)
                .Include(x => x.BodyCarColor)
                .Include(x => x.CarBodyStatus)
                .Include(x => x.InsideCarColor)
                .Include(x=>x.CarImages)
                .Include(x=>x.CreatedByUser)
                .AsQueryable()
                .Where(x=>x.CarStatus== adStatus);

            if (createdUserId.HasValue)
            {
                iqueryable = iqueryable.Where(x => x.CreatedByUserId == createdUserId);
            }

            if (viewModel.CarBrandId.HasValue)
            {
                iqueryable = iqueryable.Where(x => x.CarBrandId == viewModel.CarBrandId);
            }
            if (viewModel.CarModelId.HasValue)
            {
                iqueryable = iqueryable.Where(x => x.CarModelId == viewModel.CarModelId);
            }
            if (viewModel.CarTypeId.HasValue)
            {
                iqueryable = iqueryable.Where(x => x.CarTypeId == viewModel.CarTypeId);
            }
            
            if (viewModel.BodyCarColorId.HasValue)
            {
                iqueryable = iqueryable.Where(x => x.BodyCarColorId == viewModel.BodyCarColorId);
            }
            
            if (viewModel.InsideCarColorId.HasValue)
            {
                iqueryable = iqueryable.Where(x => x.InsideCarColorId == viewModel.InsideCarColorId);
            }
            
            if (viewModel.CarStatusId.HasValue)
            {
                iqueryable = iqueryable.Where(x => x.CarStatusId == viewModel.CarStatusId);
            }
            
            if (viewModel.FromYear.HasValue)
            {
                if (viewModel.ToYear.HasValue)
                {
                    iqueryable = iqueryable.Where(x => x.CarYear>=viewModel.FromYear.Value && x.CarYear<=viewModel.ToYear.Value);
                }
                else
                {
                    iqueryable = iqueryable.Where(x => x.CarYear >= viewModel.FromYear.Value);
                }
            }
            if (viewModel.ToYear.HasValue)
            {
                if (viewModel.FromYear.HasValue)
                {
 // در شرط بالا تنظیم شده است                   
                }
                else
                {
                    iqueryable = iqueryable.Where(x => x.CarYear <= viewModel.ToYear.Value);
                }
            }

            if (viewModel.FromPrice.HasValue)
            {
                if (viewModel.ToPrice.HasValue)
                {
                    iqueryable = iqueryable.Where(x => x.CarPrice >= viewModel.FromPrice.Value && x.CarPrice <= viewModel.ToPrice.Value);
                }
                else
                {
                    iqueryable = iqueryable.Where(x => x.CarPrice >= viewModel.FromPrice.Value);
                }
            }
            if (viewModel.ToPrice.HasValue)
            {
                if (viewModel.FromPrice.HasValue)
                {
                    // در شرط بالا تنظیم شده است                   
                }
                else
                {
                    iqueryable = iqueryable.Where(x => x.CarPrice <= viewModel.ToPrice.Value);
                }
            }

            iqueryable = iqueryable.OrderByDescending(x => x.ModifiedDateTime);

            return iqueryable;
        }
        #endregion

        #region CreateAsync
        public async Task CreateAsync(CarViewModel model)
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<CarViewModel, Car>();
            });

            IMapper iMapper = config.CreateMapper();
            var ad = iMapper.Map<CarViewModel, Car>(model);
            ad.CarImages = new List<CarImage>();

            model.filenames?
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList()
                .ForEach(x => ad.CarImages.Add(new CarImage { Filename = x }));

            await _ads.AddAsync(ad);

            var result = await _uow.SaveChangesAsync();
        }
        #endregion

        #region EditAsync
        public async Task<bool> EditAsync(CarViewModel viewModel)
        {
            var ad = await _ads.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (ad.CreatedByUserId == viewModel.CreatorUserId && ad.CarStatus!= CarStatusEnum.Void || viewModel.IsAdmin)
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CarViewModel, Car>()
                     //.ForMember(dest => dest.CarStatus, opt => opt.Condition(source => source.IsAdmin))
                     ;
                });

                IMapper iMapper = config.CreateMapper();
                iMapper.Map<CarViewModel, Car>(viewModel, ad);

                var result = await _uow.SaveChangesAsync();

                return result >= 0;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region FindByIdAsync
        public async Task<Car> FindByIdAsync(int id)
        {
            var ad = await _ads
                .Include(x=>x.CarImages)
                .Include(x=>x.CreatedByUser)
                .FirstOrDefaultAsync(x => x.Id == id);

            return ad;
        }
        #endregion

        #region RemoveImageBy_CarImageId_Or_filename_Async
        public async Task<bool> RemoveImageBy_CarImageId_Or_filename_Async(int? carImageId, string filename)
        {
            var carImage = await _carImages
                .FirstOrDefaultAsync(x => x.Id == carImageId || x.Filename==filename);

            _carImages.Remove(carImage);

            var result = await _uow.SaveChangesAsync();

            return result >= 0;
        }
        #endregion

        #region AddImageAsync
        public async Task<bool> AddImageAsync(CarImage carImage, CarStatusEnum? adStatus=null)
        {
            var ad = await _ads
                .Include(x => x.CarImages)
                .FirstOrDefaultAsync(x => x.Id == carImage.CarId);
            if (adStatus!=null)
            {
                ad.CarStatus = adStatus.Value;
            }
            ad.CarImages.Add(carImage);

            var result = await _uow.SaveChangesAsync();

            return result > 0;
        }
        #endregion

        #region ChangeCarStatusAsync
        public async Task<bool> ChangeCarStatusAsync(int id, CarStatusEnum adStatus)
        {
            var _ad =await _ads
                .FirstOrDefaultAsync(x => x.Id == id);

            _ad.CarStatus = adStatus;

            var result =await _uow.SaveChangesAsync();

            return result >= 0;
        }
        #endregion
        
        #region ChangeCarStatusAsync
        public async Task<List<Car>> HomePageSearchAsync(HomePageSearchCarViewModel viewModel, int? takeRecordCount = 20)
        {
            var iQuerable = _ads                
                .AsQueryable()
                .Where(x => x.CarStatus == CarStatusEnum.Confirmed &&
                x.CarBrandId == viewModel.CarBrandId &&
                x.CarModelId == viewModel.CarModelId &&
                x.CarTypeId == viewModel.CarTypeId);

            if (viewModel.CarStatusId.HasValue)
            {
                iQuerable = iQuerable.Where(x => x.CarStatusId == viewModel.CarStatusId);
            }

            var ads = new List<Car>();
            if (takeRecordCount.HasValue)
            {
            ads = await iQuerable
                .Include(x => x.CarBrand)
                .Include(x => x.CarModel)
                .Include(x => x.CarType)
                .OrderByDescending(x => x.ModifiedDateTime)
                .Take(takeRecordCount.Value)
                .ToListAsync();                
            }
            else
            {
                ads = await iQuerable
                .Include(x => x.CarBrand)
                .Include(x => x.CarModel)
                .Include(x => x.CarType)
                .OrderByDescending(x => x.ModifiedDateTime)
                .ToListAsync();
            }
            
            return ads;
        }
        #endregion

        #region GetMaxMin_CarPriceAsync
        public async Task<(decimal? minCarPrice, decimal? maxCarPrice)> GetMaxMin_CarPriceAsync()
        {
            decimal? _min =await _ads
                .Where(x => x.CarStatus == CarStatusEnum.Confirmed)
                .MinAsync(x => x.CarPrice),
                _max =await _ads.Where(x => x.CarStatus == CarStatusEnum.Confirmed).MaxAsync(x => x.CarPrice);

            return (_min, _max);
        }

        #endregion
    }
}
