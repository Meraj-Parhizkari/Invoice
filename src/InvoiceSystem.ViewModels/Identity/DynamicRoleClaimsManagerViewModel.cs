using DNTCommon.Web.Core;
using InvoiceSystem.Entities.Identity;
using System.Collections.Generic;

namespace InvoiceSystem.ViewModels.Identity
{
    public class DynamicRoleClaimsManagerViewModel
    {
        public string[] ActionIds { set; get; }

        public int RoleId { set; get; }

        public Role RoleIncludeRoleClaims { set; get; }

        public ICollection<MvcControllerViewModel> SecuredControllerActions { set; get; }
    }
}