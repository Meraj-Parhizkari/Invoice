using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceSystem.ViewModels.Car
{
    public class CarBrandViewModel
    {
        public int Id{ get; set; }
        [Display(Name ="نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Name { get; set; }
        [Display(Name ="عنوان")]
        public string Title { get; set; }
        [Display(Name ="سازنده")]
        public int ManufacturerId { get; set; }
    }
}
