using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceSystem.Entities.Invoice
{
    public class Order : BaseEntity
    {

        [Display(Name = "آیدی فروشنده")] public int SellerId { get; set; }
        [Display(Name = "آیدی خریدار")] [Required(ErrorMessage = "لطفا خریدار را انتخاب کنید!")] public int BuyerId { get; set; }
        [Display(Name = "شماره سفارش")] public int OrderNumber { get; set; }
        [Display(Name = "تاریخ صدور")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime CreatDatetime { get; set; }
        [Display(Name = "تاریخ سفارش")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime OrderDatetime { get; set; }
        [Display(Name = "تسویه شده")] public bool CheckedOut { get; set; }
        [Display(Name = "جمع")] public decimal Total { get; set; }
        [Display(Name = "تخفیف ")] public decimal Total_Discount { get; set; }
        [Display(Name = "جمع مالیات")] public decimal TotalTax { get; set; }
        [Display(Name = "مبلغ پرداخت")] public decimal TotalPay { get; set; }
        [Display(Name = "توضیحات")] public string Description { get; set; }
        [Display(Name = "توضیحات کاربر")] public string UserDescription { get; set; }
        [Display(Name = "جزئیات سفارش")] public ICollection<OrderDetail> OrderDetails { get; set; }
        //[Display(Name = "نام گروه محصول")] public int ProductCategoryId { get; set; }
        // public ProductCategory ProductCategory { get; set; }


        [NotMapped]
        public int? CreatedByUserId { get; set; }
        [NotMapped]
        public string CreatedByBrowserName { get; set; }
        [NotMapped]
        public string ModifiedByBrowserName { get; set; }
        [NotMapped]
        public string CreatedByIp { get; set; }
        [NotMapped]
        public string ModifiedByIp { get; set; }
        [NotMapped]
        public int? ModifiedByUserId { get; set; }
        [NotMapped]
        public DateTime? CreatedDateTime { get; set; }
        [NotMapped]
        public DateTime? ModifiedDateTime { get; set; }



    }
}
