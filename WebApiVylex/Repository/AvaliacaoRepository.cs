using Microsoft.EntityFrameworkCore;
using WebApiVylex.Data;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;

namespace WebApiVylex.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public AvaliacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Avaliacao>> GetAllAsync()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        public async Task<Avaliacao> GetByIdAsync(int id)
        {
            return await _context.Avaliacoes.FindAsync(id);
        }

        public async Task AddAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Avaliacao avaliacao)
        {
            _context.Entry(avaliacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao != null)
            {
                _context.Avaliacoes.Remove(avaliacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Avaliacoes.AnyAsync(a => a.Id == id);
        }
    }
}
