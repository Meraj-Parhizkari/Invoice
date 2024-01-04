using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceSystem.Components
{
    public class ScriptAdminLayoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Admin/_scriptAdminLayout.cshtml");
        }
    }
}
