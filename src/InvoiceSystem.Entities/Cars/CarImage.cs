using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceSystem.Entities.Cars
{
    [Table("CarImages", Schema = "Car")]
    public class CarImage : BaseEntity
    {
        #region Properties
        public int CarId { get; set; }
        [Required]
        public string Filename { get; set; }
        #endregion

        #region Navigations
        public virtual Car Car { get; set; }
        #endregion
    }
}
