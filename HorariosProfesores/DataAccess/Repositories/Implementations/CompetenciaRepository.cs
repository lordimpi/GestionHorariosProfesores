using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class CompetenciaRepository : ICompetenciaRepository
    {
        private readonly ApplicationDbContext _context;

        public CompetenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCompetenciaAsync(Competencia competencia)
        {
            _context.Add(competencia);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<Competencia>> GetAllCompetenciasAsync()
        {
            return await _context.Competencias.ToListAsync();
        }

        public async Task<Competencia> GetCompetenciaByIdAsync(int? id)
        {
            Competencia competencia = await _context.Competencias
                .Include(c => c.Programa)
                .FirstOrDefaultAsync(c => c.Competencia_Id == id);
            return competencia;
        }

        public async Task<bool> UdateCompetenciaAsync(Competencia competencia)
        {
            _context.Entry(competencia).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteCompetenciaByIdAsync(int? id)
        {
            Competencia competencia = await _context.Competencias
                .Include(c => c.Programa)
                .FirstOrDefaultAsync(c => c.Competencia_Id == id);
            
            if (competencia == null)
            {
                return false;
            }
            competencia.IsActive = false;
            _context.Update(competencia);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
