using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class PeriodoAcademico
    {
        [Key]
        public int Periodo_Id { get; set; }

        [Display(Name = "Fecha inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Periodo_FechaInicio { get; set; }

        [Display(Name = "Fecha fin")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Periodo_FechaFin { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} acepta una máximo de {1} caractéres.")]
        public string Periodo_Nombre { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        public ICollection<Programa> Programas { get; set; }

        public int CantidadProgramas => Programas == null ? 0 : Programas.Count;

        public string Estado => IsActive ? "Activo" : "Desactivo";
    }
}
