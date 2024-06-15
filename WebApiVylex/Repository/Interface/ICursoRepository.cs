using WebApiVylex.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiVylex.DTOs;

namespace WebApiVylex.Repository.Interface
{
    public interface ICursoRepository
    {
        Task<IEnumerable<CursoComAvaliacoesDto>> GetAllCursoComAvaliacaoAsync();
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso> GetByIdAsync(int id);
        Task AddAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
