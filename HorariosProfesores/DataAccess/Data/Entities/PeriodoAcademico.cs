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
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Nombre { get; set; }
        public ICollection<Programa> Programas { get; set; }
        public bool IsActive { get; set; }
    }
}
