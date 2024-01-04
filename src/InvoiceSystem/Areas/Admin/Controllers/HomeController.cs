using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InvoiceSystem.Areas.Identity;

namespace InvoiceSystem.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
