using InvoiceSystem.Common.Public;
using InvoiceSystem.Entities.AuditableEntity;
using InvoiceSystem.Entities.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Entities.Cars
{
    [Table("Cars", Schema = "Car")]
    public class Car : BaseEntity, IAuditableEntity
    {
        #region ctor
        public Car()
        {
            CarTypeStatus = CarTypeStatusEnum.Sale;
        }
        #endregion
        #region Properties
        [Display(Name = "برند")]
        public int CarBrandId { get; set; }
        [Display(Name = "مدل")]
        public int CarModelId { get; set; }
        [Display(Name = "تیپ")]
        public int CarTypeId { get; set; }
        [Display(Name = "وضعیت بدنه")]
        public int CarBodyStatusId { get; set; }
        [Display(Name = "رنگ بدنه")]
        public int BodyCarColorId { get; set; }
        [Display(Name = "رنگ داخل")]
        public int InsideCarColorId { get; set; }
        [Display(Name = "سال")]
        public int CarYear { get; set; }
        [Display(Name = "کارکرد (کیلومتر)")]
        public int CarKilometer { get; set; }
        [Display(Name = "وضعیت خودرو")]
        public CarStatusIdEnum CarStatusId { get; set; }
        [Display(Name = "نوع پلاک")]
        public CarPlateTypeEnum CarPlateTypeId { get; set; }
        [Display(Name = "وضعیت")]
        public CarPayStatusEnum CarPayStatus { get; set; }
        [Display(Name = "قیمت")]
        public decimal CarPrice { get; set; }
        [Display(Name = "محل بازدید خودرو")]
        public string CarVisitLocation { get; set; }
        [Display(Name = "شرح")]
        public string Description { get; set; }
        public CarStatusEnum CarStatus { get; set; }
        public CarTypeStatusEnum CarTypeStatus { get; set; }
        #endregion

        #region NotMapped Properties
        [NotMapped]
        [Display(Name = "شماره موبایل")]
        public string MobileNumber
        {
            get
            {
                return CreatedByUser?.UserName;
            }
        }

        [NotMapped]
        [Display(Name = "نام")]
        public string CreatedByUserDisplayName
        {
            get
            {
                return CreatedByUser?.DisplayName;
            }
        }
        [NotMapped]
        [Display(Name = "برند")]
        public string CarBrandName
        {
            get
            {
                return CarBrand?.Name;
            }
        }
        [NotMapped]
        [Display(Name = "مدل")]
        public string CarModelName
        {
            get
            {
                return CarModel?.Name;
            }
        }
        [NotMapped]
        [Display(Name = "تیپ")]
        public string CarTypeName
        {
            get
            {
                return CarType?.Name;
            }
        }
        [NotMapped]
        [Display(Name = "وضعیت")]
        public string CarStatusName
        {
            get
            {
                return Enum.IsDefined(typeof(PublicMethods.CarStatusEnum), (int)CarStatus) ? PublicMethods.CarStatus()[(int)CarStatus] : "(خالی)";
            }
        }
        [NotMapped]
        [Display(Name = "وضعیت")]
        public string CarStatusIdName
        {
            get
            {
                return Enum.IsDefined(typeof(PublicMethods.CarStatusIdEnum), (int)CarStatusId) ? PublicMethods.CarStatus()[(byte)CarStatusId] : "(خالی)";
            }
        }
        [NotMapped]
        [Display(Name = "نوع پلاک")]
        public string CarPlateTypeIdName
        {
            get
            {
                return Enum.IsDefined(typeof(PublicMethods.CarPlateTypeEnum), (int)CarPlateTypeId) ? PublicMethods.CarPlateType()[(byte)CarPlateTypeId] : "(خالی)";
            }
        }
        #endregion

        #region Navigations
        [Display(Name = "برند")]
        public virtual BaseCar CarBrand { get; set; }
        public virtual User CreatedByUser { get; set; }
        [Display(Name = "مدل")]
        public virtual BaseCar CarModel { get; set; }
        [Display(Name = "تیپ")]
        public virtual BaseCar CarType { get; set; }
        [Display(Name = "وضعیت بدنه")]
        public virtual CarBodyStatus CarBodyStatus { get; set; }
        [Display(Name = "رنگ بدنه")]
        public virtual CarColor BodyCarColor { get; set; }
        [Display(Name = "رنگ داخلی")]
        public virtual CarColor InsideCarColor { get; set; }
        [Display(Name = "تصاویر")]
        public virtual ICollection<CarImage> CarImages { get; set; }
        #endregion
    }
}
