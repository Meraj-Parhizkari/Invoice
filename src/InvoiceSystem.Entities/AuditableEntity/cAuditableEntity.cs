using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceSystem.Entities.AuditableEntity
{
    public class cAuditableEntity
    {
        #region Properties
        [Display(Name = "نام مرورگر تنظیم شده")]
        public string CreatedByBrowserName { get; set; }
        [Display(Name = "نام مرورگر اصلاح شده ")]
        public string ModifiedByBrowserName { get; set; }
        //public string DeletedByBrowserName { get; set; }
        [Display(Name = "ایجاد شده توسط Ip")]
        public string CreatedByIp { get; set; }
        [Display(Name = "اصلاح شده توسط Ip")]
        public string ModifiedByIp { get; set; }
        //public string DeletedByIp { get; set; }
        [Display(Name = "ایجاد شده توسط شناسه کاربر")]
        public int? CreatedByUserId { get; set; }
        [Display(Name = "اصلاح شده توسط شناسه کاربر")]
        public int? ModifiedByUserId { get; set; }
        //public int? DeletedByUserId { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime? CreatedDateTime { get; set; }
        [Display(Name = "تاریخ اصلاح")]
        public DateTime? ModifiedDateTime { get; set; }
        //public DateTime? DeletedDateTime { get; set; }
        #endregion

    }
}
