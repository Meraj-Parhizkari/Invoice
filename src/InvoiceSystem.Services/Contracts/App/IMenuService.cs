using InvoiceSystem.Entities.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static InvoiceSystem.Common.Public.PublicMethods;

namespace InvoiceSystem.Services.Contracts.App
{
    public interface IMenuService
    {
        Task<List<Menu>> GetMenus(MenuTypeEnum? MenuType);
        Task Create(Menu menu);
        Task<Menu> Find(int id);
        Task<Menu> Update(Menu menu );
        Task Delete(Menu menu);
    }
}
