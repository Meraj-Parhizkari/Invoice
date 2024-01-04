using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceSystem.ViewModels.Car
{
    public class CarImageViewModel
    {
        #region Properties
        public int Id { get; set; }
        public int CarId { get; set; }
        [Required]
        public string Filename { get; set; }
        #endregion
    }
}
