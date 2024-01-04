using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoiceSystem.Areas.Identity;
using InvoiceSystem.DataLayer.MSSQL;
using InvoiceSystem.Entities.App;
using InvoiceSystem.Services.Contracts.App;

namespace InvoiceSystem.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    public class MenusController : Controller
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: Admin/Menus
        public async Task<IActionResult> Index()
        {
           
            return View(await _menuService.GetMenus(null));
        }

        //// GET: Admin/Menus/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var menu = await _context.Menus
        //        .Include(m => m.Parent)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (menu == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(menu);
        //}

        // GET: Admin/Menus/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_menuService.GetMenus(null).Result, "Id", "Title");
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                _menuService.Create(menu);
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_menuService.GetMenus(null).Result, "Id", "Id", menu.ParentId);
            return View(menu);
        }

        // GET: Admin/Menus/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _menuService.Find(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_menuService.GetMenus(null).Result, "Id", "Title", menu.ParentId);
            return View(menu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _menuService.Update(menu);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            ViewData["ParentId"] = new SelectList(_menuService.GetMenus(null).Result, "Id", "Title", menu.ParentId);
            
            return View(menu);
        }

        //// GET: Admin/Menus/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _menuService.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _menuService.Find(id);
            _menuService.Delete(menu);
            
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _menuService.Find(id).Result.Id > 0 ? true : false;
        }
    }
}
