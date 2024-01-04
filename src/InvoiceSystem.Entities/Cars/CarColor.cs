using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Entities.Cars
{
    [Table("CarColors", Schema = "Car")]
    public class CarColor : BaseEntity
    {
        #region Properties
        [Required] [Display(Name = "نام")] public string Name { get; set; }
        [Display(Name = "عنوان")] public string Title { get; set; }
        [Display(Name = "فعال")] public bool IsActive { get; set; }
        [Display(Name = "نوع رنگ")] public ColorTypeEnum ColorType { get; set; }
        #endregion

        #region Navigations
        public virtual ICollection<Car> BodyCarColors { get; set; }
        public virtual ICollection<Car> InsideCarColors { get; set; }
        #endregion
    }

}
