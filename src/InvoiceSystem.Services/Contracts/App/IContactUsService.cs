using InvoiceSystem.Entities.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.App
{
    public interface IContactUsService
    {
        Task<List<ContactUs>> GetAllContactUsAsync();
        Task<bool> CreateAsync(ContactUs ContactUs);        
    }
}
