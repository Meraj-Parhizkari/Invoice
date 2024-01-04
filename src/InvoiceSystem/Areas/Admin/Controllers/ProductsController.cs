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
using InvoiceSystem.Services.Identity;
using Microsoft.AspNetCore.Authorization;

namespace InvoiceSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = ConstantRoles.AdminUser)]
    //[Authorize(Roles = "Admin,User")]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _product;
        private readonly IProductCategoryService _productCategory;

        public ProductsController(
            IProductService product,
            IProductCategoryService productCategory)
        {
            _product = product;
            _productCategory = productCategory;
        }

        // GET: Admin/Products
        // نمایش لیست گروه کالا
        public async Task<IActionResult> Index()
        {
            ViewData["ProductCategoryId"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            var userId = User.Identity.GetUserId<int>();
            var result = await _product.GetAll(userId);
            return View( result);
        }

        // Post Admin/Products/GetProductByProductCategoryId
        // گرفتن لیست کالا از طریق گروه کالا
        [HttpPost]
        public async Task<IActionResult> GetProductByProductCategoryId(int id) {

            List<Product> products = new List<Product>();
            products = await _product.GetProductByProductCategoryId(id);
            return Json(products);
        }

        // GET: Admin/Products/Details/5
        // نمایش اطلاعات یک ردیف از طریق ایدی
        public async Task<IActionResult> Details(int id)
        {
            var userId = User.Identity.GetUserId<int>();
            var product = await _product.FindAsync(id,userId);

            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            return View(product);
        }

        // GET: Admin/Products/Create
        // نمایش صفحه ایجاد مشتری
        public async Task<IActionResult> Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");

            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات و ذخیره آن
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _product.Create(product);
                // await _Product.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        // نمایش اطلاعات برای ویراش از طریق ایدی
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = await _product.FindAsync(id,User.Identity.GetUserId<int>());
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            return View(product);
            
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات برای ویرایش در صفحه ویرایش از طریق ایدی
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            var userId = User.Identity.GetUserId<int>();

            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _product.Update(product,userId);
                    
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            //ViewData["ProductCategoryId"] = new SelectList(await _productCategory.GetAll(), "Id", "Name");
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        // نمایش اطلاعات برای پاک کردن
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _product.FindAsync(id, User.Identity.GetUserId<int>());

            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(await _productCategory.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            return View(product);
            
        }
        // POST: Admin/Products/Delete/5
        // پاک کردن یک ردیف از طریق ایدی
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = User.Identity.GetUserId<int>();
            var product = await _product.FindAsync(id, User.Identity.GetUserId<int>());
            _product.Remove(product,userId);
            
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return false;
        }

        // ایجاد کالا از طریق ajax
        [HttpPost]
        public async Task<IActionResult> CreateProductwhitAjax(Product model)
        {
            if (ModelState.IsValid)
            {
                Product product = await _product.Create(model);
                return Json(new { success = true, entity = product });
            }
            return Json(new { error = true, entity = model });
        }
    }
}
