using InvoiceSystem.Common.GuardToolkit;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.App;

using InvoiceSystem.Services.Contracts.App;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.App
{
    public class ContactUsService : IContactUsService
    {
        #region Properties
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ContactUs> _contactUs;
        #endregion

        #region Ctor
        public ContactUsService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _contactUs = _uow.Set<ContactUs>();
            _contactUs.CheckArgumentIsNull(nameof(_contactUs));
        }
        #endregion

        #region CreateAsync
        public async Task<bool> CreateAsync(ContactUs ContactUs)
        {
            await _contactUs
                .AddAsync(ContactUs);

            var result = await _uow.SaveChangesAsync();

            return result > 0;
        }
        #endregion

        #region GetAllContactUsAsync
        public Task<List<ContactUs>> GetAllContactUsAsync()
        {
            return _contactUs
                .ToListAsync();
        }
        #endregion
    }
}
