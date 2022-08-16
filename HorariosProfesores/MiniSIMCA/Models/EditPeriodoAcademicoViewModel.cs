using System.ComponentModel.DataAnnotations;

namespace MiniSIMCA.Models
{
    public class EditPeriodoAcademicoViewModel
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} acepta una máximo de {1} caractéres.")]
        public string Periodo_Nombre { get; set; }

        [Display(Name = "Fecha inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Periodo_FechaInicio { get; set; }

        [Display(Name = "Fecha fin")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Periodo_FechaFin { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }
    }
}
