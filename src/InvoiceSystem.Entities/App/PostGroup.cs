
using InvoiceSystem.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceSystem.Entities.App
{
    [Table("PostGroups", Schema = "app")]
    public class PostGroup:BaseEntity,IAuditableEntity
    {
        #region Properties
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [MaxLength(int.MaxValue)]
        public string Description { get; set; }
        [Display(Name = "والد")]
        public int? ParentId { get; set; }
        [Display(Name = "وضعیت")]
        public byte Status { get; set; }
        [Display(Name = "زبان")]
        public byte LanguageId { get; set; }
        [Display(Name = "ترتیب")]
        public int SortOrder { get; set; }
        [Display(Name = "اسلاگ")]
        public string Slug { get; set; }
        [Display(Name = "نمایش در صفحات اصلی")]
        public bool IsShowHomepage { get; set; }
        #endregion

        #region NotMapped
        [NotMapped]
        public string ParentName
        {
            get
            {
                return Parent?.Name;
            }
        }
        #endregion

        #region Navigations
        public virtual ICollection<PostPostGroup> PostPostGroups{ get; set; }
        public virtual ICollection<PostGroup> Children{ get; set; }
        public virtual PostGroup Parent{ get; set; }
        #endregion
    }
}