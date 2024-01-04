using AutoMapper;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.App;
using InvoiceSystem.Services.Contracts.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Public
{
    public abstract class BaseService : IBaseService
    {
        #region ctor
        public BaseService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public BaseService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }
        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public BaseService(IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        #endregion

        #region Properties
        //public ServiceMethodResult serviceMethodResult = new ServiceMethodResult();

        protected IUnitOfWork _uow;
        protected IMapper _mapper;
        protected IApplicationUserManager _applicationUserManager;
        protected IHttpContextAccessor _httpContextAccessor;

        protected DbSet<Post> _posts;
        protected DbSet<PostGroup> _postGroups;
        #endregion

        #region Remove
        public async Task<bool> Remove<TEntity>(TEntity entity) where TEntity : class
        {
            _uow.Remove<TEntity>(entity);
            var result = await _uow.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> RemoveAsync<TEntity>(int id) where TEntity : class
        {
            var entity = _uow.FirstOrDefault<TEntity>(id);
            if (entity != null)
            {
                _uow.Remove<TEntity>(entity);
            }
            var result = await _uow.SaveChangesAsync();

            return result > 0;
        }
        #endregion
    }
}
