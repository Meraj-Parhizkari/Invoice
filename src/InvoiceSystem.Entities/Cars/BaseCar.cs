using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Entities.Cars
{
    [Table("BaseCars", Schema = "Car")]
    public class BaseCar : BaseEntity
    {
        #region Properties
        public int Cid { get; set; }
        [Display(Name = "شناسه والد")] public int? ParentId { get; set; }
        [Display(Name = "نام")] public string Name { get; set; }
        [Display(Name = "والد")] public CarFTypeEnum CarFType { get; set; }
        #endregion

        #region Naviagations
        public virtual BaseCar Parent { get; set; }
        public virtual ICollection<BaseCar> Children { get; set; }
        public virtual ICollection<Car> CarCarBrands { get; set; }
        public virtual ICollection<Car> CarCarModels { get; set; }
        public virtual ICollection<Car> CarCarTypes { get; set; }
        #endregion
    }
}
