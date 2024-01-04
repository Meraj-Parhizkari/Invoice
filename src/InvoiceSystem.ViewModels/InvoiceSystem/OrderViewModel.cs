using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceSystem.ViewModels.InvoiceSystem
{
    public class OrderViewModel
    {
        [Display(Name = "آیدی فروشنده")] public int SellerId { get; set; }
        [Display(Name = "آیدی خریدار")] public int BuyerId { get; set; }
        [Display(Name = "شماره سفارش")] public int OrderNumber { get; set; }
        [Display(Name = "تاریخ صدور")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime CreatDatetime { get; set; }
        [Display(Name = "تاریخ سفارش")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime OrderDatetime { get; set; }
        [Display(Name = "بررسی شده؟")] public bool CheckedOut { get; set; }
        [Display(Name = "جمع")] public decimal Total { get; set; }
        [Display(Name = "تخفیف ")] public decimal Total_Discount { get; set; }
        [Display(Name = "جمع مالیات")] public decimal TotalTax { get; set; }
        [Display(Name = "مبلغ پرداخت")] public decimal TotalPay { get; set; }
        [Display(Name = "توضیحات")] public string Description { get; set; }
        [Display(Name = "توضیحات کاربر")] public string UserDescription { get; set; }
        [Display(Name = "جزئیات سفارش")] public ICollection<OrderDetailViewModel> OrderDetail { get; set; }
    }                                   
}
