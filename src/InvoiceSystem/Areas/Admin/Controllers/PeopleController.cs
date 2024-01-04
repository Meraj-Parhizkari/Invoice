using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoiceSystem.DataLayer.MSSQL;
using InvoiceSystem.Entities.Invoice;
using InvoiceSystem.Services.Contracts.InvoiceSystem;
using InvoiceSystem.Common.IdentityToolkit;
using static InvoiceSystem.Common.Public.PublicMethods;
using InvoiceSystem.Services.Identity;
using Microsoft.AspNetCore.Authorization;

namespace InvoiceSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = ConstantRoles.AdminUser)]
    [Area("Admin")]
    public class PeopleController : Controller
    {
        private readonly IPersonService _person;
        private readonly ICountryDivisionsService _countryDivisions;

        public PeopleController(IPersonService person, ICountryDivisionsService countryDivisions)
        {
            _person = person;
            _countryDivisions = countryDivisions;
        }

        // GET: Admin/People
        // نمایش لیست مشتری ها
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var result = await _person.GetAll(userId);
            return View(result);
        }

        // GET: Admin/People/Details/5
        // نمایش اطلاعات یک ردیف از طریق ایدی
        public async Task<IActionResult> Details(int id)
        {
           

            var userId = User.Identity.GetUserId<int>();

            var person = await _person.FindAsync(id, userId);
            if (person == null)
            {
                return NotFound();
            }
            var cities = await _countryDivisions.GetAllCitiesByCityId(person.TownId);
            ViewData["countryDivisionsprovince"] = new SelectList(await _countryDivisions.GetAllProvince(), "Id", "Name",cities.First().ParentId);
            ViewData["countryDivisionsId"] = new SelectList(cities, "Id", "Name",person.TownId);
            //ViewData["PersonTypeId"] = new SelectList(await _person.GetAll(), "Id", "Name");
            return View(person);
        }

        // GET: Admin/People/Create
        // نمایش صفحه ایجاد مشتری
        public async Task<IActionResult> Create()
        {
            var countries = await _countryDivisions.GetAll();
           
            ViewData["countryDivisionsprovince"] = new SelectList(countries.Where(x => x.Type == DivisionEnum.Province), "Id", "Name");
            ViewData["countryDivisionsId"] = new SelectList(countries.Where(x => x.Type == DivisionEnum.City), "Id", "Name");

            return View();
        }

        // POST: Admin/People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات و ذخیره آن
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
              await _person.Create(person);
                //await _person.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        // GET: Admin/People/Edit/5
        // نمایش اطلاعات برای ویراش از طریق ایدی

        public async Task<IActionResult> Edit(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var person = await _person.FindAsync(id, User.Identity.GetUserId<int>());
            if (person == null)
            {
                return NotFound();
            }
            var countries = await _countryDivisions.GetAll();
            int provinceId = Convert.ToInt32(countries.FirstOrDefault(x => x.Id == person.TownId).ParentId);        
            var cities = await _countryDivisions.GetAllCitiesByCityId(person.TownId);
            ViewData["countryDivisionsprovince"] = new SelectList(countries.Where(x => x.Type == DivisionEnum.Province), "Id", "Name", provinceId);
            ViewData["countryDivisionsId"] = new SelectList(cities, "Id", "Name", cities.First().ParentId);



            return View(person);

        }

        // POST: Admin/People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات برای ویرایش در صفحه ویرایش از طریق ایدی

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            var userId = User.Identity.GetUserId<int>();
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _person.Update(person, userId);
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {

                    return View(person);

                }

                return View(person);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/People/Delete/5
        // نمایش اطلاعات برای پاک کردن

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _person.FindAsync(id, User.Identity.GetUserId<int>());

            if (person == null)
            {
                return NotFound();
            }

            var cities = await _countryDivisions.GetAllCitiesByCityId(person.TownId);
            ViewData["countryDivisionsprovince"] = new SelectList(await _countryDivisions.GetAllProvince(), "Id", "Name", cities.First().ParentId);
            ViewData["countryDivisionsId"] = new SelectList(cities, "Id", "Name", person.TownId);
            //ViewData["countryDivisionsId"] = new SelectList(countries.Where(x => x.Type == DivisionEnum.City), "Id", "Name", person.TownId);
            return View(person);

        }

        // POST: Admin/People/Delete/5
        // پاک کردن یک ردیف از طریق ایدی
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = User.Identity.GetUserId<int>();
            var people = await _person.FindAsync(id, User.Identity.GetUserId<int>());
            _person.Remove(people, userId);

            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            //return _context.People.Any(e => e.Id == id);
            return false;
        }
        // ایجاد مشتری از طریق ajax
        public async Task<IActionResult> CreatePeoplewhitAjax(Person model)
        {
            if (ModelState.IsValid)
            {
                Person person = await _person.Create(model);
                return Json(new { success = true, entity = person });
            }
            return Json(new { error = true, entity = model });
        }
        //public async Task<IActionResult> GetPeopleList()
        //{
        //    var result = await _person.GetAll();
        //    return Json(result.Select(x => new { x.Id, x.Name }));
        //}
        // گرفتن لیست مشتری ها
        public async Task<IActionResult> GetPeopleList()
        {
            List<Person> people = new List<Person>();
            people = await _person.GetAll(User.Identity.GetUserId<int>());
            return Json(people.Select(x => new { x.Id, x.Name }));
        }
    }
}
