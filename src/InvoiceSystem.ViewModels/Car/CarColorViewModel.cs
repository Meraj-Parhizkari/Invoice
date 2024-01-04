using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceSystem.ViewModels.Car
{
    public class CarColorViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")] [Required]  public string Name { get; set; }
        [Display(Name = "عنوان")]  public string Title { get; set; }
        [Display(Name = "فعال")] public bool IsActive { get; set; }
    }
}
