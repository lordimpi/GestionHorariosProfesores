using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class ProgramaRepository : IProgramaRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePrograma(Programa programa)
        {
            _context.Add(programa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePrograma(int? id)
        {
            Programa programa = await _context.Programas.FindAsync(id);
            if (programa == null)
            {
                return false;
            }
            programa.IsActivo = false;
            _context.Update(programa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Programa> GetProgramaById(int? id)
        {
            Programa programa = await _context.Programas
                .Include(p => p.Competencias)
                .FirstOrDefaultAsync(p => p.Programa_Id == id);
            return programa;
        }

        public async Task<ICollection<Programa>> GetProgramas()
        {
            List<Programa> lista = await _context.Programas
                .Include(p => p.Competencias)
                .ToListAsync();
            return lista;
        }

        public async Task<bool> ModifyPrograma(Programa programa)
        {
            _context.Entry(programa).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
