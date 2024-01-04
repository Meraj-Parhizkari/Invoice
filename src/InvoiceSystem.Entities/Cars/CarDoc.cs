using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceSystem.Entities.Cars
{
    [Table("CarDocs", Schema = "Car")]
    public class CarDoc : BaseEntity
    {

        [Required]
        [Display(Name = "نام")] public string Name { get; set; }
        [Display(Name = "فعال")] public bool IsActive { get; set; }

    }
}
