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
using InvoiceSystem.ViewModels.InvoiceSystem;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Data;
using InvoiceSystem.Common.IdentityToolkit;
using Microsoft.AspNetCore.Authorization;
using InvoiceSystem.Services.Identity;

namespace InvoiceSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = ConstantRoles.AdminUser)]
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IPersonService _personService;
        private readonly ICountryDivisionsService _countryDivisions;




        public OrdersController(
            IOrderService order,
            IProductCategoryService productCategory,
            IPersonService personService,
            ICountryDivisionsService countryDivisions)
        {
            _orderService = order;
            _productCategoryService = productCategory;
            _personService = personService;
            _countryDivisions = countryDivisions;
        }

        // GET: Admin/Orders
        // نمایش لیست سفارش های کاربر 
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var result = await _orderService.GetAll(userId);

            //ViewData["OrderId"] = new SelectList(await _orderService.GetAll(),"Id","ProductName");
            ViewData["name"] = User.Identity.GetUserId<int>();

            return View(result);
        }


        // GET: Admin/Orders/Details/5
        // دریافت جزئیات یک ردیف از طریق ایدی
        public async Task<IActionResult> Details(int id)
        {
            ViewData["PersonId"] = new SelectList(await _personService.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            var userId = User.Identity.GetUserId<int>();
            Order order = await _orderService.FindAsync(id, userId);
            return View(order);
        }

        // GET: Admin/Orders/Create
        // نمایش صفحه ایجاد سفارش 
        public async Task<IActionResult> Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(await _productCategoryService.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            ViewData["PersonId"] = new SelectList(await _personService.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            ViewData["countryDivisionsId"] = new SelectList(await _countryDivisions.GetAllProvince(), "Id", "Name");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات و ذخیره آن
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            
            //var b= JsonConvert.DeserializeObject<List<OrderDetail>>(HttpContext.Session.GetString("Card").ToString());

            order.OrderDetails = new List<OrderDetail>();


            if (ModelState.IsValid)
            {
                var orderDetailsList = JsonConvert.DeserializeObject<List<OrderDetail>>(HttpContext.Session.GetString("Card").ToString());
                foreach (var item in orderDetailsList)
                {
                    item.OrderId = order.Id;
                    order.OrderDetails.Add(item);

                }
                // محاسبه جمع کل
                order.Total = order.OrderDetails.Sum(x => x.ProductCount * x.ProductPrice);
                // محاسبه جمع تخفیف 
                order.Total_Discount = order.OrderDetails.Sum(x => x.ProductDiscunt);
                // محاسبه جمع تخفیف
                order.TotalTax = order.OrderDetails.Sum(x => (x.ProductCount * x.ProductPrice)-x.ProductDiscunt) * Convert.ToDecimal(0.09) ;
                // محاسبه قیمت نهایی
                order.TotalPay = order.Total - order.Total_Discount + order.TotalTax;

                //order.SellerId = User.Identity.GetUserId<int>();
               await _orderService.Create(order);
                return RedirectToAction(nameof(Index));
            }

            return View(order);

        }
        //POST : گرفتن اطلاعات یک ردیف فاکتور و ذخیره کردن آن در سشن
        [HttpPost]
        public async Task<IActionResult> AddtoList(OrderDetail orderDetail)
        {
            List<OrderDetailViewModel> itemList = new List<OrderDetailViewModel>();
            if (HttpContext.Session.GetString("Card") != null)
            {
                itemList = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(HttpContext.Session.GetString("Card").ToString());
            }
            if (itemList.Any(x => x.ProductId == orderDetail.ProductId))
            {
                OrderDetailViewModel orderItem = itemList.First(x => x.ProductId == orderDetail.ProductId);
                orderItem.ProductCount += orderDetail.ProductCount;
                orderItem.ProductPrice = orderDetail.ProductPrice;
                orderItem.ProductDiscunt = orderDetail.ProductDiscunt;
            }
            else
            {
                var item = new OrderDetailViewModel()
                {
                    Id = orderDetail.Id,
                    ProductId = orderDetail.ProductId,
                    ProductName = $"{orderDetail.ProductCode}-{orderDetail.ProductName}",
                    ProductCount = orderDetail.ProductCount,
                    Unit = orderDetail.Unit,
                    ProductPrice = orderDetail.ProductPrice,
                    ProductDiscunt = orderDetail.ProductDiscunt,
                    ProductTax = orderDetail.ProductTax,
                };
                itemList.Add(item);
            }
            HttpContext.Session.SetString("Card", JsonConvert.SerializeObject(itemList));
            return PartialView("_ShoppingList");

        }

        // گرفتن اطلاعات سفارش از طریق ایدی سفارش
        [HttpPost]
        public async Task<IActionResult> GetOrderDetailsByOrderId(int id)
        {
            List<OrderDetail> orderDetails = await _orderService.GetOrderDetailsByOrderId(id);
            return PartialView("_orderDetailList", orderDetails);

        }

        // پاک کردن یک ردیف از لیست فاکتور
        [HttpPost]
        public IActionResult RemoveRemoveItemFromShoppingCard(int id)
        {
            List<OrderDetailViewModel> itemList = new List<OrderDetailViewModel>();
            if (HttpContext.Session.GetString("Card") != null)
            {
                itemList = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(HttpContext.Session.GetString("Card").ToString());
            }
            if (itemList.Any(x => x.ProductId == id))
            {
                itemList.Remove(itemList.First(x => x.ProductId == id));
                HttpContext.Session.SetString("Card", JsonConvert.SerializeObject(itemList));
                return Json(true);
            }
            return Json(false);
        }

        // نمایش اطلاعات سشن
        public IActionResult ShowShoppingList()
        {
            return PartialView("_ShoppingList");
        }

        // نمایش اطلاعات برای ویراش از طریق ایدی
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["PersonId"] = new SelectList(await _personService.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");

            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.FindAsync(id, User.Identity.GetUserId<int>());
            if (order == null)
            {
                return NotFound();
            }
            return View(order);

        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // گرفتن اطلاعات برای ویرایش در صفحه ویرایش از طریق ایدی
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {

            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _orderService.Update(order, User.Identity.GetUserId<int>());
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(order);
                }
                return View(order);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Orders/Delete/5
        // نمایش اطلاعات برای پاک کردن
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.FindAsync(id, User.Identity.GetUserId<int>());
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        // پاک کردن یک ردیف از طریق ایدی
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _orderService.FindAsync(id, User.Identity.GetUserId<int>());
            _orderService.Remove(order, User.Identity.GetUserId<int>());
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return false;
        }

        // کپی کردن اطلاعات یه سفارش و رفتن به صفحه ایجاد و نمایش اطلاعات کپی شده
        public async Task<IActionResult> CopyAndCreate(int id)
        {
            ViewData["ProductCategoryId"] = new SelectList(await _productCategoryService.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");
            ViewData["PersonId"] = new SelectList(await _personService.GetAll(User.Identity.GetUserId<int>()), "Id", "Name");

            Order order = await _orderService.FindAsync(id, User.Identity.GetUserId<int>());
            if (order != null)
            {
                List<OrderDetailViewModel> orderDetail = new List<OrderDetailViewModel>();
                foreach (var od in order.OrderDetails)
                {
                    orderDetail.Add(new OrderDetailViewModel()
                    {
                        Id = od.Id,
                        OrderId = od.OrderId,
                        ProductId = od.ProductId,
                        ProductName = od.ProductName,
                        ProductCount = od.ProductCount,
                        Unit = od.Unit,
                        ProductDiscunt = od.ProductDiscunt,
                        ProductPrice = od.ProductPrice,
                        ProductTax = od.ProductTax
                    });
                }
                HttpContext.Session.SetString("Card", JsonConvert.SerializeObject(orderDetail));                
                return View("Create");
            }

            return PartialView("_ShoppingList");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // نمایش فاکتور در shofactor
        public IActionResult ShowFactor()
        {
            return View();
        }
        public IActionResult GetReport()
        {
            StiReport report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/PishFactor.mrt"));
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
