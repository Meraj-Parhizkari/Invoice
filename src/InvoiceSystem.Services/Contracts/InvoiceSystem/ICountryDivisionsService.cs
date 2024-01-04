using InvoiceSystem.Entities.Invoice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.InvoiceSystem
{
    public  interface ICountryDivisionsService
    {
        Task<CountryDivision> FindAsync(int id);    
        Task<List<CountryDivision>> GetAll();
        Task<List<CountryDivision>> GetAllProvince();
        Task<CountryDivision> Create(CountryDivision countryDivision);
        void Update(CountryDivision countryDivision);
        void Remove(CountryDivision countryDivision);
        Task<List<CountryDivision>> GetCountryDivisionsByParentId(int id);
        Task<List<CountryDivision>> GetAllCitiesByCityId(int id);
    }

}
