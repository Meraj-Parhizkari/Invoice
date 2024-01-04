using InvoiceSystem.Common.GuardToolkit;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.App;

using InvoiceSystem.Services.Contracts.App;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static InvoiceSystem.Common.Public.PublicMethods;
using System.Linq;

namespace InvoiceSystem.Services.App
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Menu> _menu;
        public MenuService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _menu = _uow.Set<Menu>();
            _menu.CheckArgumentIsNull(nameof(_menu));

        }

        public async Task Create(Menu menu)
        {

            await _menu.AddAsync(menu);

            var result = await _uow.SaveChangesAsync();
        }

        public Task<List<Menu>> GetMenus(MenuTypeEnum? menuTypeEnum)
        {
            if (menuTypeEnum != null)
            {
                string type = menuTypeEnum.ToString();
                return _menu.Include(m => m.Parent).Where(x => x.Type == type).ToListAsync();
            }
            return _menu.Include(m => m.Parent).ToListAsync();
        }
        public async Task<Menu> Find(int id)
        {
            return await _menu.FindAsync(id);
        }


        public async Task<Menu> Update(Menu menu)
        {
            _menu.Update(menu);
            await _uow.SaveChangesAsync();
            return menu;
        }

        public async Task Delete(Menu menu)
        {
            _menu.Remove(menu);
            await _uow.SaveChangesAsync();
        }
    }
}
