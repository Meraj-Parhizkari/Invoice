using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceSystem.Entities.App
{

    [Table("Menus", Schema = "app")]
    public class Menu
    {
        [Display(Name= "شناسه")]public int Id { get; set; }
        [Display(Name= "نام")]public string Name { get; set; }
        [Display(Name= "عنوان")]public string Title { get; set; }
        [Display(Name= "لینک")]public string Link { get; set; }
        [Display(Name= "آیکون")]public string Icon { get; set; }
        [Display(Name= "ترتیب")]public int SortOrder { get; set; }
        [Display(Name= "فعال")]public bool IsActive { get; set; }
        [Display(Name= "نوع")]public string Type { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        [Display(Name = "والد")] public virtual Menu Parent { get; set; }
        //public ICollection<Menu> SubMenus { get; set; }

    }
}
