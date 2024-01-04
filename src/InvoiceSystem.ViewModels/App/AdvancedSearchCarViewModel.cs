using InvoiceSystem.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.ViewModels.App
{
    public class AdvancedSearchCarViewModel
    {
        public int? page { get; set; } = 1;
        public int pageSize { get; set; } = 6;
        [Display(Name = "برند")]
        //[Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public int? CarBrandId { get; set; }
        [Display(Name = "مدل")]
        public int? CarModelId { get; set; }
        [Display(Name = "تیپ")]
        public int? CarTypeId { get; set; }
        [Display(Name = "از")]
        public int? FromYear { get; set; }
        [Display(Name = "تا")]
        public int? ToYear { get; set; }
        [Display(Name = "از")]
        public int? FromPrice { get; set; }
        [Display(Name = "تا")]
        public int? ToPrice { get; set; }
        [Display(Name = "رنگ بدنه")]
        public int? BodyCarColorId { get; set; }
        [Display(Name = "رنگ داخل")]
        public int? InsideCarColorId { get; set; }
        [Display(Name = "وضعیت خودرو")]
        public CarStatusIdEnum? CarStatusId { get; set; }
    }
}
