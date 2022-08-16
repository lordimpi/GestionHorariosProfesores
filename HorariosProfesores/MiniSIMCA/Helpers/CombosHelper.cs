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

        public IEnumerable<SelectListItem> GetComboArea()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetComboDiasSemana()
        {
            List<SelectListItem> list = new()
            {
                new SelectListItem()
                {
                    Text = "Lunes",
                    Value = DiaSemana.Lunes.ToString()
                },
                new SelectListItem()
                {
                    Text = "Martes",
                    Value = DiaSemana.Martes.ToString()
                },
                new SelectListItem()
                {
                    Text = "Miercoles",
                    Value = DiaSemana.Miercoles.ToString()
                },
                new SelectListItem()
                {
                    Text = "Jueves",
                    Value = DiaSemana.Jueves.ToString()
                },
                new SelectListItem()
                {
                    Text = "Viernes",
                    Value = DiaSemana.Viernes.ToString()
                },
                new SelectListItem()
                {
                    Text = "Sabado",
                    Value = DiaSemana.Sabado.ToString()
                }
            };
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione el tipo de competencia...]",
                Value = "0"
            });
            return list;
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

        public IEnumerable<SelectListItem> GetComboTipoContrato()
        {
            List<SelectListItem> list = new()
            {
                new SelectListItem()
                {
                    Text = "Planta",
                    Value = $"{TipoContrato.Planta}"
                },
                new SelectListItem()
                {
                    Text = "Contratista",
                    Value = $"{TipoContrato.Contratista}"
                },
            };
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione el tipo de contrato...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboTipoDocente()
        {
            List<SelectListItem> list = new()
            {
                new SelectListItem()
                {
                    Text = "Profesional",
                    Value = $"{TipoDocente.Profesional}"
                },
                new SelectListItem()
                {
                    Text = "Técnico",
                    Value = $"{TipoDocente.Tecnico}"
                },
            };
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione el tipo de docente...]",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboTipoIdentificacion()
        {
            List<SelectListItem> list = new()
            {
                new SelectListItem()
                {
                    Text = "Cédula de ciudadanía",
                    Value = $"{TipoIdentificacion.Cedula}"
                },
                new SelectListItem()
                {
                    Text = "Cédula de extranjería",
                    Value = $"{TipoIdentificacion.CedulaDelExterior}"
                },
                new SelectListItem()
                {
                    Text = "Pasaporte",
                    Value = $"{TipoIdentificacion.Pasaporte}"
                },
                new SelectListItem()
                {
                    Text = "Tarjeta de identidad",
                    Value = $"{TipoIdentificacion.TarjetaIdentidad}"
                },
                new SelectListItem()
                {
                    Text = "Licencia de conducción",
                    Value = $"{TipoIdentificacion.LicenciaDeConduccion}"
                },
            };
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione el tipo de documento...]",
                Value = "0"
            });
            return list;
        }
    }
}
