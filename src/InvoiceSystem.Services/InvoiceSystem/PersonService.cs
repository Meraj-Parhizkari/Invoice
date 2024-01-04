using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.Invoice;
using InvoiceSystem.Services.Contracts.InvoiceSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.InvoiceSystem
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Person> _person;

        public PersonService(
            IUnitOfWork uow
            )
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _person = uow.Set<Person>();
        }

        public async Task<List<Person>> GetAll(int userId)
        {
            return await _person.Where(x => x.CreatedByUserId == userId).ToListAsync();
        }

        public async Task<Person> Create(Person person)
        {
            _person.Add(person);
            await _uow.SaveChangesAsync();
            return person;
        }

        public void Update(Person person, int userId)
        {

            if (_person.Any(x => x.CreatedByUserId == userId && x.Id == person.Id))
            {
                person.CreatedByUserId = userId;
                _person.Update(person);
                _uow.SaveChangesAsync();
            }

        }

        public async Task<Person> FindAsync(int id, int userId)
        {

            return await _person.FirstOrDefaultAsync(x => x.CreatedByUserId == userId && x.Id == id);


        }

        public async void Delete(Person person)
        {
            _person.Remove(person);
            await _uow.SaveChangesAsync();
        }

        public async void DeleteById(int id)
        {
            _person.Remove(await _person.FindAsync(id));
            await _uow.SaveChangesAsync();

        }

        public void Remove(Person person, int userId)
        {
            if (_person.Any(x => x.CreatedByUserId == userId && x.Id == person.Id))
            {
                _person.Remove(person);
                _uow.SaveChangesAsync();
            }
        }
    }
}
