using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceSystem.ViewModels.Car
{
    public class CarDocViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")] public string Name { get; set; }
        [Display(Name = "فعال")] public bool IsActive { get; set; }

    }
}
