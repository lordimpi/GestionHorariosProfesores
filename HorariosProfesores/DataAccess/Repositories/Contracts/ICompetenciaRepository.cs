using DataAccess.Data.Entities;

namespace DataAccess.Repositories.Contracts
{
    public interface ICompetenciaRepository
    {
        Task<ICollection<Competencia>> GetAllCompetenciasAsync();
        Task<Competencia> GetCompetenciaByIdAsync(int? id);
        Task<bool> CreateCompetenciaAsync(Competencia competencia);
        Task<bool> UdateCompetenciaAsync(Competencia competencia);
        Task<bool> DeleteCompetenciaByIdAsync(int? id);

    }
}
