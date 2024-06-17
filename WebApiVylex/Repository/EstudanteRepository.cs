using Microsoft.EntityFrameworkCore;
using WebApiVylex.Data;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;

namespace WebApiVylex.Repository
{
    public class EstudanteRepository : IEstudanteRepository
    {
        private readonly ApplicationDbContext _context;
        public EstudanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Estudante>> GetAllAsync()
        {
            return await _context.Estudantes.ToListAsync();
        }
        public async Task<Estudante> GetByIdAsync(int id)
        {
            return await _context.Estudantes.FindAsync(id);
        }
        public async Task AddAsync(Estudante estudante)
        {
            _context.Estudantes.Add(estudante);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Estudante estudante)
        {
            _context.Entry(estudante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante != null)
            {
                _context.Estudantes.Remove(estudante);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Estudantes.AnyAsync(e => e.Id == id);
        }
    }
}
