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
using InvoiceSystem.Services.Identity;
using Microsoft.AspNetCore.Authorization;

namespace InvoiceSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = ConstantRoles.Admin)]
    [Area("Admin")]
    public class CountryDivisionsController : Controller
    {
        private readonly ICountryDivisionsService _countryDivisions;

        public CountryDivisionsController(
            ICountryDivisionsService countryDivisions)
        {
            _countryDivisions = countryDivisions;
        }

        // GET: Admin/CountryDivisions
        // نمایش لیست شهر ها واستان ها
        public async Task<IActionResult> Index()
        {
            var result = await _countryDivisions.GetAll();
            return View(result);


        }

        // GET: Admin/CountryDivisions/Details/5
        //  نمایش جزئیات شهر یا استان با ایدی 
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryDivision = await _countryDivisions.FindAsync(id);
            if (countryDivision == null)
            {
                return NotFound();
            }
            return View(countryDivision);
        }

        // GET: Admin/CountryDivisions/Create
        // نمایش صفحه ایجاد شهر یا استان 
        public async Task<IActionResult> Create()
        {
            ViewData["ParentId"] = new SelectList(await _countryDivisions.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Admin/CountryDivisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات و ذخیره آن
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryDivision countryDivision)
        {
            _countryDivisions.Create(countryDivision);
            return RedirectToAction(nameof(Index));
            return View(countryDivision);
        }

        // GET: Admin/CountryDivisions/Edit/5
        // نمایش اطلاعات برای ویراش از طریق ایدی
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryDivision = await _countryDivisions.FindAsync(id);
            if (countryDivision == null)
            {
                return NotFound();
            }
            return View(countryDivision);
        }

        // POST: Admin/CountryDivisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات برای ویرایش در صفحه ویرایش از طریق ایدی
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CountryDivision countryDivision)
        {
            if (id != countryDivision.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _countryDivisions.Update(countryDivision);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {

                    return View(countryDivision);

                }
                return View(countryDivision);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/CountryDivisions/Delete/5
        // نمایش اطلاعات برای پاک کردن
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryDivision = await _countryDivisions.FindAsync(id);
            if (countryDivision == null)
            {
                return NotFound();
            }

            return View(countryDivision);
        }

        // POST: Admin/CountryDivisions/Delete/5
        // پاک کردن یک ردیف از طریق ایدی
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryDivision = await _countryDivisions.FindAsync(id);
            _countryDivisions.Remove(countryDivision);
            return RedirectToAction(nameof(Index));
        }

        private bool CountryDivisionExists(int id)
        {
            return false;
        }
        // گرفتن شهر های استان مورد نظر
        [HttpPost]
        public async Task<IActionResult> GetCountryDivisionsByParentId(int id)
        {
            List<CountryDivision> countryDivision = new List<CountryDivision>();
            countryDivision = await _countryDivisions.GetCountryDivisionsByParentId(id);
            return Json(countryDivision);
        }
    }
}
