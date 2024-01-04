using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.Invoice;
using InvoiceSystem.Services.Contracts.InvoiceSystem;
using InvoiceSystem.ViewModels.InvoiceSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.InvoiceSystem
{
    public class CountryDivisionsService : ICountryDivisionsService
    {
        private IUnitOfWork _uow;
        private DbSet<CountryDivision> _countryDivisions;

        public CountryDivisionsService(
            IUnitOfWork uow
            )
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _countryDivisions = uow.Set<CountryDivision>();
        }
        public async Task<CountryDivision> Create(CountryDivision countryDivision)
        {
            _countryDivisions.Add(countryDivision);
            await _uow.SaveChangesAsync();
            return countryDivision;

        }
        public void Update(CountryDivision CountryDivision)
        {
            _countryDivisions.Update(CountryDivision);
            _uow.SaveChangesAsync();
        }
        public async Task<CountryDivision> FindAsync(int id)
        {
            return await _countryDivisions.FindAsync(id);
        }

        public async Task<List<CountryDivision>> GetAll()
        {

            return await _countryDivisions.ToListAsync();
        }

        public void Remove(CountryDivision CountryDivision)
        {
            _countryDivisions.Remove(CountryDivision);
            _uow.SaveChangesAsync();
        }

        public Task<List<CountryDivision>> GetCountryDivisionsByParentId(int id)
        {
            return _countryDivisions.Where(x => x.ParentId == id).ToListAsync();
        }
        public async Task<List<CountryDivision>> GetAllProvince()
        {
            return await _countryDivisions.Where(x => x.Type == Common.Public.PublicMethods.DivisionEnum.Province).ToListAsync();
        }

        public async Task<List<CountryDivision>> GetAllCitiesByCityId(int id)
        {
            int parentId = Convert.ToInt32(_countryDivisions.Find(id).ParentId);
            return await GetCountryDivisionsByParentId(parentId);
        }
    }
}
