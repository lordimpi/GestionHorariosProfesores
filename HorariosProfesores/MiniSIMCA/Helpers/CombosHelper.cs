using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Data.Enums;
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

        public async Task<IEnumerable<SelectListItem>> GetComboProgramasAsync(IEnumerable<Programa> filter)
        {
            List<Programa> programas = await _context.Programas.ToListAsync();
            List<Programa> programasFiltered = new();
            foreach (Programa programa in programas)
            {
                if (!filter.Any(p => p.Programa_Id == programa.Programa_Id))
                {
                    programasFiltered.Add(programa);
                }
            }

            List<SelectListItem> list = programasFiltered.Select(p => new SelectListItem
            {
                Text = p.Programa_Nombre,
                Value = p.Programa_Id.ToString()
            })
                .OrderBy(p => p.Text)
                .ToList();

            list.Insert(0, new SelectListItem { Text = "[Seleccione un programa...", Value = "0" });
            return list;
        }


        public IEnumerable<SelectListItem> GetComboTipoCompetencia()
        {

            List<SelectListItem> list = new()
            {
                new SelectListItem()
                {
                    Text = "Generica",
                    Value = $"{TipoCompetencia.Generica}"
                },
                new SelectListItem()
                {
                    Text = "Especifica",
                    Value = $"{TipoCompetencia.Especifica}"
                }
            };
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione el tipo de competencia...]",
                Value = "0"
            });
            return list;

        }
    }
}
