using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceSystem.Entities.Invoice
{
    public class OrderDetail 
    {
        public static object itemList;

        public int Id { get; set; }
        public int OrderId  { get; set; }
        [Required(ErrorMessage = "لطفا محصول را انتخاب کنید!")]
        public int ProductId { get; set; }
        [Display(Name = "کد محصول")]
        public string ProductCode { get; set; }
        [Display(Name = "محصول")]
        [Required(ErrorMessage = "لطفا {0} را انتخاب کنید!")]
        public string ProductName { get; set; }
        [Display(Name = "تعداد")]
        [Range(1, int.MaxValue, ErrorMessage = "لطفا {0} را بیشتر از 0 وارد کنید!")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        public decimal ProductCount { get; set; }
        public string Unit { get; set; }
        [Display(Name = "قیمت")]
        [Range(1, int.MaxValue, ErrorMessage = "لطفا {0} را بیشتر از 0 وارد کنید!")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        public decimal ProductPrice { get; set; }
        [Display(Name = "تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        public decimal ProductDiscunt { get; set; }
        public decimal ProductTax { get; set; }
        public  Order Order { get; set; }
    }
}
