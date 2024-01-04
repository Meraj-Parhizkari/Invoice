using InvoiceSystem.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.ViewModels.App
{
    public class ContactUsViewModel
    {
        #region Properties
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")] 
        public string YourName  { get; set; }
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Mobile  { get; set; }
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "فرمت {0} اشتباه است")]
        public string Email  { get; set; }
        [Display(Name = "پیام")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Message  { get; set; }
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public ContactUsStatusEnum ContactUsStatus { get; set; }
        #endregion        
    }
}
