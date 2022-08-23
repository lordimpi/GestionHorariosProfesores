using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementations
{
    public class AmbienteRepository : IAmbienteRepository
    {
        private readonly ApplicationDbContext _context;

        public AmbienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAmbienteAsync(Ambiente ambiente)
        {
            _context.Add(ambiente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<Ambiente>> GetAllAmbientesAsync()
        {
            List<Ambiente> ambientes = await _context.Ambientes.ToListAsync();
            return ambientes;
        }

        public async Task<Ambiente> GetAmbienteByIdAsync(int? id)
        {
            Ambiente ambiente = await _context.Ambientes.FindAsync(id);
            return ambiente;
        }

        public async Task<bool> UdateAmbienteAsync(Ambiente ambiente)
        {
            _context.Entry(ambiente).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAmbienteByIdAsync(int? id)
        {
            Ambiente ambiente = await _context.Ambientes.FindAsync(id);
            if (ambiente == null)
            {
                return false;
            }
            ambiente.IsActive = false;
            _context.Update(ambiente);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
