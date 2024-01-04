using InvoiceSystem.Entities.AuditableEntity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Entities.App
{
    [Table("Posts", Schema = "app")]
    public class Post : BaseEntity, IAuditableEntity
    {
        #region Properties
        public PostTypeEnum Type { get; set; }
        [MaxLength(300, ErrorMessage = "لطفا {0} را کمتر از {1} حرف وارد نمائید!")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید!")]
        [Display(Name = "نام")]
        [StringLength(300)]
        public string Name { get; set; }
        [MaxLength(300, ErrorMessage = "لطفا {0} را کمتر از {1} حرف وارد نمائید!")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید!")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [MaxLength(150, ErrorMessage = "لطفا {0} را کمتر از {1} حرف وارد نمائید!")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید!")]
        [Display(Name = "Slug")]
        public string Slug { get; set; }
        [MaxLength(300, ErrorMessage = "لطفا {0} را کمتر از {1} حرف وارد نمائید!")]
        [Display(Name = "کلمات کلیدی")]
        public string MetaKeywords { get; set; }
        [MaxLength(1024, ErrorMessage = "لطفا {0} را کمتر از {1} حرف وارد نمائید!")]
        [Display(Name = "خلاصه")]
        public string PostSummery { get; set; }
        [MaxLength(300, ErrorMessage = "لطفا {0} را کمتر از {1} حرف وارد نمائید!")]
        [Display(Name = "توضیح")]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید!")]
        [Display(Name = "متن")]
        [MaxLength(int.MaxValue)]
        //[AllowHtml]
        public string PostContent { get; set; }
        [Display(Name = "تصویر")]
        public string Image { get; set; }
        [Display(Name = "تصویر بزرگ")]
        public string SmallImage { get; set; }
        [Display(Name = "تصویر متوسط")]
        public string MediumImage { get; set; }
        [Display(Name = "تصویر کوچک")]
        public string BigImage { get; set; }
        [Display(Name = "تصویر زمینه")]
        public string BackgroundImage { get; set; }
        public int VisitCount { get; set; }
        public string PostLike { get; set; }
        public float PostRate { get; set; }
        [Display(Name = "تاریخ انتشار")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime PublishDatetime { get; set; }
        [Display(Name = "تاریخ انقضاء")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime? ExpiredDatetime { get; set; }
        [Display(Name = "فعال بودن نظردهی")]
        public bool IsActiveComments { get; set; }
        [Display(Name = "زبان")]
        public LanguageEnum LanguageId { get; set; }
        [Display(Name = "فعال")]
        public bool IsActive { get; set; }
        #endregion

        #region NotMapped
        [NotMapped]
        public string PostGroupNames
        {
            get
            {
                return PostPostGroups?.Aggregate("", (current, next) => current + ", " + next.PostGroup?.Name);
            }
        }
        #endregion
        #region Navigation
        [Display(Name = "گروه مطالب")]
        public ICollection<PostPostGroup> PostPostGroups { get; set; }
        #endregion
    }
}