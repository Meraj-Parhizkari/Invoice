using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.ViewModels.Car
{
    public class BaseCarViewModel
    {
        #region Properties
        public int Id { get; set; }
        //public int Cid { get; set; }
        [Display(Name = "شناسه والد")] public int? ParentId { get; set; }
        [Display(Name = "نام")] public string Name { get; set; }
        [Display(Name = "نام برند")] public string BrandName { get; set; }
        [Display(Name = "نام مدل")] public string ModelName { get; set; }
        //[Display(Name = "والد")] public CarFTypeEnum CarFType { get; set; }
        public bool HasChildren { get; set; }
        #endregion    
    }
}
