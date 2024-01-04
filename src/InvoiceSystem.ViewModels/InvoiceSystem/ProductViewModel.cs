using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.ViewModels.InvoiceSystem
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public int ProdactCategoryId { get; set; }
        public ProductCategoryViewModel ProductCategory { get; set; }

    }
}
