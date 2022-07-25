using DataAccess.Data.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MiniSIMCA.Models
{
    public class CompetenciaViewModel
    {

        [Display(Name = "Nombre competencia")]
        [MaxLength(100, ErrorMessage = "La cantidad máxima de caractéres es {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Competencia_Nombre { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        public IEnumerable<SelectListItem> TipoCompetencias { get; set; }

        [Display(Name ="Tipo de competencia")]
        public int Competencia_Id { get; set; }

        public TipoCompetencia TipoCompetencia { get; set; }

        public int ProgramaId { get; set; }
    }
}
