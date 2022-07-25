using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MiniSIMCA.Models
{
    public class AddPeriodoAcademicoViewModel
    {
        public int PeriodoId { get; set; }

        [Display(Name = "Programa")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un programa.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ProgramaId { get; set; }

        public IEnumerable<SelectListItem> Programas { get; set; }
    }
}
