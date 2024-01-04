using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.ViewModels.Car
{
    public class CarViewModel
    {
        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// در هنگام ویرایش شدن اجازه مپ شدن فیلد
        /// CarStatus
        /// را تنظیم می کند
        /// </summary>
        public bool IsAdmin { get; set; }
        public string MobileNumber { get; set; }
        public string DisplayName { get; set; }
        public int? CreatorUserId { get; set; }
        [Display(Name = "برند")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public int CarBrandId { get; set; }
        [Display(Name = "مدل")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public int CarModelId { get; set; }
        [Display(Name = "تیپ")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public int CarTypeId { get; set; }
        [Display(Name = "سال")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public int CarYear { get; set; }
        [Display(Name = "کارکرد (هزار کیلومتر)")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public int CarKilometer { get; set; }
        [Display(Name = "وضعیت خودرو")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public CarStatusIdEnum CarStatusId { get; set; }
        [Display(Name = "نوع پلاک")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public CarPlateTypeEnum CarPlateTypeId { get; set; }
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public CarPayStatusEnum CarPayStatus { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public decimal CarPrice { get; set; }
        [Display(Name = "وضعیت بدنه")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public int CarBodyStatusId { get; set; }
        [Display(Name = "رنگ بدنه")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public int BodyCarColorId { get; set; }
        [Display(Name = "رنگ داخل")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public int InsideCarColorId { get; set; }
        public string CarVisitLocation { get; set; }
        public string Description { get; set; }
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public CarStatusEnum CarStatus { get; set; }
        public CarTypeStatusEnum CarTypeStatus { get; set; }

        //public ICollection<CarAdImageViewModel> CarAdImages { get; set; }
        public List<string> filenames { get; set; }
        public List<int> AdImageIds { get; set; }

        public string CreatedByUserDisplayName { get; set; }
        public string CarBrandName { get; set; }
        public string CarModelName { get; set; }
        public string CarTypeName { get; set; }
        public string CarStatusIdName { get; set; }
        public string CarPlateTypeIdName { get; set; }
        public string CarStatusName { get; set; }
        #endregion
    }
}
