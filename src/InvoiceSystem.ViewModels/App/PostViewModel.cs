using InvoiceSystem.Entities.AuditableEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.ViewModels.App
{
    public class PostViewModel
    {
        #region Properties
        public int Id { get; set; }
        [Required(ErrorMessage = "نوع پست نامشخص است.")]
        [Display(Name = "نوع")]
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
        [Remote("SlugExists", "Blogs", "Admin", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "این {0} قبلا ثبت شده است!")]
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
        [Display(Name = "فعال")]
        public bool IsActive { get; set; }
        [Display(Name = "پست گروه ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید!")]
        public List<int> PostGroupsIds { get; set; }
        [Display(Name = "تصویر زمینه")]
        public IFormFile BackgroundFile { get; set; }
        [Display(Name = "تصویر کوچک")]
        public IFormFile ThumbnailFile { get; set; }
        public string PostGroupNames { get; set; }
        #endregion
    }
}