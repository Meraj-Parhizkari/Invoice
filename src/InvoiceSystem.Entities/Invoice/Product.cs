using InvoiceSystem.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceSystem.Entities.Invoice
{
    public class Product : IAuditableEntity
    {

        public int Id { get; set; }
        [Display(Name = "کد کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        public int ProductCode { get; set; }
        [Display(Name = "نام کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        public string ProductName { get; set; }
        [Display(Name = "نام گروه محصول")]
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        [NotMapped]
        public int? CreatedByUserId { get; set; }
    }
}
