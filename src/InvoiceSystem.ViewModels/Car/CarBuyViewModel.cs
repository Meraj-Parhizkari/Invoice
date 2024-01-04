using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Entities
{
    public class CarBuyViewModel
    {
        #region Properties
        public int Id { get; set; }
        [Display(Name = "Customer", ResourceType = typeof(Resources.SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.SharedResource))]
        public int CustomerId { get; set; }
        [Display(Name = "Manufacturer", ResourceType = typeof(Resources.SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.SharedResource))]
        public int ManufacturerId { get; set; }
        [Display(Name = "CarBrand", ResourceType = typeof(Resources.SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.SharedResource))]
        public int CarBrandId { get; set; }
        [Display(Name = "CarType", ResourceType = typeof(Resources.SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.SharedResource))]
        public int CarTypeId { get; set; }
        [Display(Name = "CarColor", ResourceType = typeof(Resources.SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.SharedResource))]
        public int CarColorId { get; set; }
        [Display(Name = "Date", ResourceType = typeof(Resources.SharedResource))]
        //[DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy/MM/dd}")]
        public DateTime? BuyDate { get; set; }
        [Display(Name = "InvoiceCode", ResourceType = typeof(Resources.SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.SharedResource))]
        [Remote("CheckInvoiceCode","CarBuys",AdditionalFields ="Id", HttpMethod = "POST",ErrorMessageResourceName ="CheckInvoiceCode",ErrorMessageResourceType =typeof(Resources.SharedResource))]
        public string InvoiceCode { get; set; }
        [Display(Name = "VIN", ResourceType = typeof(Resources.SharedResource))]
        public string VIN { get; set; }
        [Display(Name = "EngineNo", ResourceType = typeof(Resources.SharedResource))]
        public string EngineNo { get; set; }
        [Display(Name = "BuildYear", ResourceType = typeof(Resources.SharedResource))]
        public int? BuildYear { get; set; }
        [Display(Name = "PlateNo", ResourceType = typeof(Resources.SharedResource))]
        public string PlateNo { get; set; }
        [Display(Name = "BuyAmount", ResourceType = typeof(Resources.SharedResource))]
        public decimal? BuyAmount { get; set; }
        [Display(Name = "SaleAmount", ResourceType = typeof(Resources.SharedResource))]
        public decimal? SaleAmount { get; set; }
        [Display(Name = "BuyType", ResourceType = typeof(Resources.SharedResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.SharedResource))]
        public BuyTypeEnum BuyType { get; set; }
        [Display(Name = "IsSale", ResourceType = typeof(Resources.SharedResource))]
        public bool IsSale { get; set; }
        [Display(Name = "LocationName", ResourceType = typeof(Resources.SharedResource))]
        public string LocationName { get; set; }
        [Display(Name = "Description", ResourceType = typeof(Resources.SharedResource))]
        public string Description { get; set; }
        [Display(Name = "DriverName", ResourceType = typeof(Resources.SharedResource))]
        public string DriverName { get; set; }
        [Display(Name = "DriverMobile", ResourceType = typeof(Resources.SharedResource))]
        public string DriverMobile { get; set; }
        [Display(Name = "IsConfirm", ResourceType = typeof(Resources.SharedResource))]
        public bool IsConfirm { get; set; }
        [Display(Name = "ArticleCode", ResourceType = typeof(Resources.SharedResource))]
        public int? ArticleCode { get; set; }
        [Display(Name = "FiscalYear", ResourceType = typeof(Resources.SharedResource))]
        public int? FiscalYear { get; set; }
        [Display(Name = "CompanyCode", ResourceType = typeof(Resources.SharedResource))]
        public string CompanyCode { get; set; }
        #endregion
    }
}
