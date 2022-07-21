using DataAccess.Data.Entities;

namespace Infrastructure.Services.Contracts
{
    public interface IPeriodoAcademicoService
    {
        Task<ICollection<PeriodoAcademico>> GetAllPeriodosAcamedicosAsync();
        Task<PeriodoAcademico> GetPeriodoAcamedicoByIdAsync(int? id);
        Task<bool> CreatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico);
        Task<bool> UpdatePeriodoAcamedicoAsync(PeriodoAcademico periodoAcademico);
        Task<bool> DeletePeriodoAcamedicoByIdAsync(int? id);
    }
}
