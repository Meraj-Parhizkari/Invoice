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
using Newtonsoft.Json;
using InvoiceSystem.Common.IdentityToolkit;
using InvoiceSystem.Services.Identity;
using Microsoft.AspNetCore.Authorization;

namespace InvoiceSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = ConstantRoles.AdminUser)]
    [Area("Admin")]
    public class ProductCategoriesController : Controller
    {
        private readonly IProductCategoryService _productCategory;

        public ProductCategoriesController(IProductCategoryService productCategory)
        {
            _productCategory = productCategory;
        }

        // GET: Admin/ProductCategories
        // نمایش لیست گروه کالا
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var result = await _productCategory.GetAll(userId);
            return View(result);
        }

        // GET: Admin/ProductCategories/Details/5
        // نمایش اطلاعات یک ردیف از طریق ایدی

        public async Task<IActionResult> Details(int id)
        {

            var userId = User.Identity.GetUserId<int>();
            var productCategory = await _productCategory.FindAsync(id,userId);
            if (productCategory == null)
            {
                return NotFound();
            }

            ViewData["Parents"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            return View(productCategory);

        }

        // GET: Admin/ProductCategories/Create
        // نمایش صفحه ایجاد مشتری
        public async Task<IActionResult> Create()
        {
            ViewData["Parents"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            return View();
        }
        // POST: Admin/ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات و ذخیره آن
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategory productCategory)
        {
            //var userId=User.Identity.GetUserId<int>();
            //if (ModelState.IsValid)
            //{
               await _productCategory.Create(productCategory);
                //await _productCategory.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["Parents"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name", productCategory.ParentId);

            return View(productCategory);

        }

        // نمایش لیست گروه کالا
        public async Task<IActionResult> ShowProductCategoryList()
        {
            //List<ProductCategory> productCategories = new List<ProductCategory>();
            var result = await _productCategory.GetAll(User.Identity.GetUserId<int>());
            return Json(result.Select(x => new { x.Id, x.Name }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // ایجاد از طریق ajax
        public async Task<IActionResult> CreateAjax(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _productCategory.Create(productCategory);
                //await _productCategory.SaveChangesAsync();
                return Json(new { success = true, entity = productCategory });
            }

            return Json(new { error = true, entity = productCategory });

        }
        // GET: Admin/ProductCategories/Edit/5
        // نمایش اطلاعات برای ویراش از طریق ایدی
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productCategory = await _productCategory.FindAsync(id, User.Identity.GetUserId<int>());
            if (productCategory == null)
            {
                return NotFound();
            }

            ViewData["Parents"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name", productCategory.ParentId);

            return View(productCategory);

        }

        // POST: Admin/ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات برای ویرایش در صفحه ویرایش از طریق ایدی
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductCategory productCategory)
        {
            var userId = User.Identity.GetUserId<int>();

          

            if (id != productCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productCategory.Update(productCategory,userId);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Parents"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name", productCategory.ParentId);
            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Delete/5
        // نمایش اطلاعات برای پاک کردن
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = await _productCategory.FindAsync(id, User.Identity.GetUserId<int>());
            if (productCategory == null)
            {
                return NotFound();
            }
            ViewData["Parents"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            return View(productCategory);

        }

        // POST: Admin/ProductCategories/Delete/5
        // پاک کردن یک ردیف از طریق ایدی
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = User.Identity.GetUserId<int>();
            var productCategory = await _productCategory.FindAsync(id, User.Identity.GetUserId<int>());
            _productCategory.Remove(productCategory,userId);

            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryExists(int id)
        {
            //return _productCategory.ProductCategories.Any(e => e.Id == id);
            return false;
        }
    }
}
