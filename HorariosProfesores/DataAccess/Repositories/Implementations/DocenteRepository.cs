using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class DocenteRepository : IDocenteRepository
    {
        private readonly ApplicationDbContext _context;

        public DocenteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateDocenteAsync(Docente docente)
        {
            _context.Add(docente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<Docente>> GetAllDocentesAsync()
        {
            List<Docente> docentes = await _context.Docentes.ToListAsync();
            return docentes;
        }

        public async Task<Docente> GetDocenteByIdAsync(int? id)
        {
            Docente docente = await _context.Docentes.FindAsync(id);
            return docente;
        }

        public async Task<bool> UdateDocenteAsync(Docente docente)
        {
            _context.Entry(docente).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDocenteByIdAsync(int? id)
        {
            Docente docente = await _context.Docentes.FindAsync(id);
            if (docente == null)
            {
                return false;
            }

            docente.IsActive = false;
            _context.Update(docente);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
