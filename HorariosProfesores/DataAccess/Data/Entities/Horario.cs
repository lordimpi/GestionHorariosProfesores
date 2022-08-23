using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class Horario
    {
        public int Id { get; set; }

        [Display(Name = "Dia")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Horario_Dia { get; set; }

        [Display(Name = "Hora inicio")]
        [Range(7, 22, ErrorMessage = "Las hora debe estar comprendida de 7 a 22 horas.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Horario_Hora_Inicio { get; set; }

        [Display(Name = "Hora fin")]
        [Range(7, 22, ErrorMessage = "Las hora debe estar comprendida de 7 a 22 horas.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Horario_Hora_Fin { get; set; }

        [Display(Name = "Duración")]
        public int Horario_Duracion { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        //Relations
        [Display(Name = "Docente")]
        public User User { get; set; }

        [Display(Name = "Periodo Académico")]
        public int PeriodoAcademicoId { get; set; }

        [Display(Name = "Ambiente")]
        public Ambiente Ambiente { get; set; }
    }
}
