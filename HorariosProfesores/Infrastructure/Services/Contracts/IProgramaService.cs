using DataAccess.Data.Entities;

namespace Infrastructure.Services.Contracts
{
    public interface IProgramaService
    {
        Task<ICollection<Programa>> GetProgramas();
        Task<Programa> GetProgramaById(int? programaId);
        Task<bool> CreatePrograma(Programa programa);
        Task<bool> ModifyPrograma(Programa programa);
        Task<bool> DeletePrograma(int? id);
    }
}
