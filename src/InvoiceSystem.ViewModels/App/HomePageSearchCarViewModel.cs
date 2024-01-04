using InvoiceSystem.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.ViewModels.App
{
    public class HomePageSearchCarViewModel
    {
        [Display(Name = "برند")]
        [Required(ErrorMessage = "*")]
        public int? CarBrandId { get; set; }
        [Display(Name = "مدل")]
        [Required(ErrorMessage = "*")]
        public int? CarModelId { get; set; }
        [Display(Name = "تیپ")]
        [Required(ErrorMessage = "*")]
        public int? CarTypeId { get; set; }
        public CarStatusIdEnum? CarStatusId { get; set; }
    }
}
