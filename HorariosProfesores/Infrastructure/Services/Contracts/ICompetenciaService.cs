using DataAccess.Data.Entities;

namespace Infrastructure.Services.Contracts
{
    public interface ICompetenciaService
    {
        Task<ICollection<Competencia>> GetAllCompetenciasAsync();
        Task<Competencia> GetCompetenciaByIdAsync(int? id);
        Task<bool> CreateCompetenciaAsync(Competencia competencia);
        Task<bool> UdateCompetenciaAsync(Competencia competencia);
        Task<bool> DeleteCompetenciaByIdAsync(int? id);
    }
}
