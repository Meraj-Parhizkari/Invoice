using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceSystem.Entities
{
   public abstract class BaseEntity : SystemEntity
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
    }
}
