using InvoiceSystem.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceSystem.Entities
{
    public abstract class SystemEntity : IAuditableEntity
    {
        [Display(Name = "کد نماینده")] public int SystemId { get; set; }
    }
}
