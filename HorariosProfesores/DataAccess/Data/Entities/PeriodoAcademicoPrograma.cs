using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class PeriodoAcademicoPrograma
    {
        public int PeriodoAcademicoId { get; set; }
        public int ProgramaId { get; set; }
        public PeriodoAcademico PeriodoAcademico { get; set; }
        public Programa Programa { get; set; }
    }
}
