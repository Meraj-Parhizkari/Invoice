using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceSystem.Entities.Cars
{
    [Table("CarBodyStatuses", Schema = "Car")]
    public class CarBodyStatus : BaseEntity
    {
        public CarBodyStatus()
        {
            IsActive = false;
        }
        [Display(Name = "عنوان")] public string Name { get; set; }
        [Display(Name = "فعال")] public bool IsActive { get; set; }

        #region Navigations
        public virtual ICollection<Car> Cars { get; set; }
        #endregion
    }
}
