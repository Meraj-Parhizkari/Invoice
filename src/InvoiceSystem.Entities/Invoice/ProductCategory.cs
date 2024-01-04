using InvoiceSystem.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceSystem.Entities.Invoice
{
    public class ProductCategory : IAuditableEntity
    {
        [Display(Name="شناسه")]
        public int Id { get; set; }
        [Display(Name="نام")] [Required(ErrorMessage = "لطفا {0} را وارد کنید!")] public string Name { get; set; }
       public int? ParentId { get; set; }
        [Display(Name="محصولات")]public ICollection<Product> Products { get; set; }
        [Display(Name = "والد")] public ProductCategory Parent { get; set; }

        [NotMapped]
        public int? CreatedByUserId { get; set; }

    }
}
