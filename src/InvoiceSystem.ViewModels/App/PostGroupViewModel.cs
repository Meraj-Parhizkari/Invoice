
using InvoiceSystem.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceSystem.ViewModels.App
{
    public class PostGroupViewModel
    {
        #region Properties
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید!")]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید!")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(int.MaxValue)]
        public string Description { get; set; }
        [Display(Name = "والد")]
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
        [Display(Name = "وضعیت")]
        public byte Status { get; set; }
        [Display(Name = "ترتیب")]
        public int SortOrder { get; set; }
        [Display(Name = "اسلاگ")]
        public string Slug { get; set; }
        [Display(Name = "نمایش در صفحات اصلی")]
        public bool IsShowHomepage { get; set; }
        #endregion
    }
}