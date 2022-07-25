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

        public async Task<bool> CreateDocenteAsync(User docente)
        {
            _context.Add(docente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<User>> GetAllDocentesAsync()
        {
            List<User> docentes = await _context.Users.ToListAsync();
            return docentes;
        }

        public async Task<User> GetDocenteByIdAsync(int? id)
        {
            User docente = await _context.Users.FindAsync(id);
            return docente;
        }

        public async Task<bool> UdateDocenteAsync(User docente)
        {
            _context.Entry(docente).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDocenteByIdAsync(int? id)
        {
            User docente = await _context.Users.FindAsync(id);
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
