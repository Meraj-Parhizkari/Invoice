using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceSystem.ViewModels.Car
{
    public class CarTypeViewModel
    {
        #region Properties
        public int Id { get; set; }
        [Display(Name="کد")]
        public string CarCode { get; set; }
        [Display(Name="نام")]
        public string Name { get; set; }
        [Display(Name="عنوان")]
        public string Title { get; set; }
        [Display(Name="فعال")]
        public bool IsActive { get; set; }
        [Display(Name = "سازنده")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        public int ManufacturerId { get; set; }
        [Display(Name="برند خودرو")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        public int CarBrandId { get; set; }
        #endregion

    }

}
