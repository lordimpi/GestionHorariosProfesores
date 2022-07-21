using DataAccess.Data.Entities;

namespace DataAccess.Repositories.Contracts
{
    public interface IPeriodoAcademicoRepository
    {
        Task<ICollection<PeriodoAcademico>> GetAllPeriodosAcamedicosAsync();
        Task<PeriodoAcademico> GetPeriodoAcamedicoByIdAsync(int? id);
        Task<bool> CreatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico);
        Task<bool> UpdatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico);
        Task<bool> DeletePeriodoAcamedicoByIdAsync(int? id);
    }
}
