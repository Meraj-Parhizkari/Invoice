using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.ViewModels.InvoiceSystem
{
  public  class ProductCategoryViewModel
  
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
        public ProductCategoryViewModel Parent { get; set; }
    }
}
