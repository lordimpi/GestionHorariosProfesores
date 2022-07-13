using System.ComponentModel.DataAnnotations;

namespace MiniSIMCA.Models
{
    public class CompetenciaViewModel
    {
        [Key]
        public int Competencia_Id { get; set; }

        [Display(Name = "Nombre competencia")]
        [MaxLength(100, ErrorMessage = "La cantidad máxima de caractéres es {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Competencia_Nombre { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        public int ProgramaId { get; set; }
    }
}
