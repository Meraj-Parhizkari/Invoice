using InvoiceSystem.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Entities.App
{
    [Table("ContactUs", Schema = "app")]
    public class ContactUs : BaseEntity, IAuditableEntity
    {
        #region Properties
        [Required]
        public string YourName  { get; set; }
        [Required]
        public string Mobile  { get; set; }
        public string Email  { get; set; }
        [Required]
        public string Message  { get; set; }
        public ContactUsStatusEnum ContactUsStatus { get; set; }
        #endregion        
    }
}
