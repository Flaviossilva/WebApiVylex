using Microsoft.EntityFrameworkCore;
using WebApiVylex.Data;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;

namespace WebApiVylex.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task AddAsync(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Curso curso)
        {
            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Cursos.AnyAsync(c => c.Id == id);
        }
    }

}
