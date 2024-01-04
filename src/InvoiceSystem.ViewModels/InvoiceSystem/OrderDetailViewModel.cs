using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSystem.ViewModels.InvoiceSystem
{
    public class OrderDetailViewModel
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductCount { get; set; }
        public string Unit { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscunt { get; set; }
        public decimal ProductTax { get; set; }
        public OrderViewModel Order { get; set; }
    }

}
