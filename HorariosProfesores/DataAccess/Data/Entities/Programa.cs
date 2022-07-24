using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class Programa
    {
        [Key]
        public int Programa_Id { get; set; }

        [Display(Name = "Nombre del programa")]
        [MaxLength(50, ErrorMessage = "La cantidad máxima de caractéres es de {1}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Programa_Nombre { get; set; }

        [Display(Name = "Estado")]
        public bool IsActivo { get; set; }

        public ICollection<Competencia> Competencias { get; set; }

        public ICollection<PeriodoAcademicoPrograma> PeriodoAcademicoProgramas { get; set; }

        [Display(Name = "Competencias")]
        public int CompetenciasNumber => Competencias == null ? 0 : Competencias.Count;

        public string Estate => IsActivo ? "Activo" : "No Activo";
    }
}
