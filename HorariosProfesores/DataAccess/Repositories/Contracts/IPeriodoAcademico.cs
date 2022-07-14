using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Repositories.Contracts
{
    public interface IPeriodoAcademico
    {
        Task<ICollection<PeriodoAcademico>> GetAllPeriodosAcamedicosAsync();
        Task<PeriodoAcademico> GetPeriodoAcamedicoByIdAsync(int? id);
        Task<bool> CreatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico);
        Task<bool> UpdatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico);
        Task<bool> DeletePeriodoAcamedicoByIdAsync(int? id);
    }
}
