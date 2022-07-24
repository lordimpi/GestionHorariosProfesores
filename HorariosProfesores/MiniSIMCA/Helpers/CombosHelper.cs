using DataAccess.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MiniSIMCA.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly ApplicationDbContext _context;

        public CombosHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboProgramasAsync()
        {

            List<SelectListItem> list = await _context.Programas.Select(x => new SelectListItem
            {
                Text = x.Programa_Nombre,
                Value = $"{x.Programa_Id}"
            })
            .OrderBy(x => x.Text)
            .ToListAsync();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Programa...]",
                Value = "0"
            });
            return list;

        }
    }
}
