using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceSystem.Entities.App
{
    [Table("PostPostGroups", Schema = "app")]
    public class PostPostGroup
    {
        #region Properties
        public int PostId { get; set; }
        public int PostGroupId { get; set; }
        #endregion

        #region Navigations
        public virtual Post Post { get; set; }
        public virtual PostGroup PostGroup { get; set; }
        #endregion
    }
}