using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Entities.Invoice
{
    public class CountryDivision
    {
        public int Id { get; set; }        
        [Display(Name = "نام شهر یا استان")]
        public string Name { get; set; }
        [Display(Name = "نوع")]
        public DivisionEnum Type { get; set; }
        [Display(Name = "والد")]
        public int? ParentId { get; set; }
        public CountryDivision Parent { get; set; }
    }
}
