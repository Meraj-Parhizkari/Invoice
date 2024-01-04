using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Entities.Invoice
{
    public class Person : BaseEntity 
    {
        
      [Display(Name="نام")] [Required(ErrorMessage ="لطفا {0} را وارد کنید!")] public string Name { get; set; }
      [Display(Name="شماره اقتصادی")] [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        [StringLength(12, ErrorMessage = "لطفا {0} را {1} رقم وارد کنید!", MinimumLength = 12)] 
        public string EconomicalNumber { get; set; }
      [Display(Name="شماره ثبت")] [Required(ErrorMessage = "لطفا {0} را وارد کنید!")] public string RegisterNumber { get; set; }
      [Display(Name="شهر")] [Required(ErrorMessage = "لطفا {0} را وارد کنید!")] public int TownId { get; set; }
      [Display(Name="آدرس")] [Required(ErrorMessage = "لطفا {0} را وارد کنید!")] public string Address { get; set; }
      [Display(Name="کد پستی")] [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        [StringLength(10, ErrorMessage = "لطفا {0} را {1} رقم وارد کنید!", MinimumLength = 10)] 
        public string ZipCode { get; set; }
      [Display(Name="کد ملی")] [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        [StringLength(10,ErrorMessage ="لطفا {0} را {1} رقم وارد کنید!",MinimumLength =10)]
        public string NationalCode { get; set; }
      [Display(Name="تلفن")] [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        [StringLength(11, ErrorMessage = "لطفا {0} را {1} رقم وارد کنید!", MinimumLength = 11)]
        public string Phone { get; set; }
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید!")]
        [StringLength(11, ErrorMessage = "لطفا {0} را {1} رقم وارد کنید!", MinimumLength = 11)]
        public string Mobile { get; set; }
        [Display(Name="فکس")]  public string Fax { get; set; }
      [Display(Name="نوع شخص")] public PersonTypeEnum PersonTypeId { get; set; }
      [Display(Name="فعال")]  public bool IsActive { get; set; }
      [Display(Name="ایمیل")]  public string Email { get; set; }

        [NotMapped]
        public int? CreatedByUserId { get; set; }
        [NotMapped]
        public string CreatedByBrowserName { get; set; }
        [NotMapped]
        public string ModifiedByBrowserName { get; set; }
        [NotMapped]
        public string CreatedByIp { get; set; }
        [NotMapped]
        public string ModifiedByIp { get; set; }
        [NotMapped]
        public int? ModifiedByUserId { get; set; }
        [NotMapped]
        public DateTime? CreatedDateTime { get; set; }
        [NotMapped]
        public DateTime? ModifiedDateTime { get; set; }

    }
}
