using InvoiceSystem.Entities.Invoice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.InvoiceSystem
{
    public interface IPersonService
    {
        Task<Person> Create(Person person);
        void Delete(Person person);
        Task<Person> FindAsync(int id,int userId);
        Task<List<Person>> GetAll(int userId);
        void Update(Person person,int userId);
        void Remove(Person person,int userId);
    }
}
