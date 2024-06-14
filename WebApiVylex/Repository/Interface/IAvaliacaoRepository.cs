using WebApiVylex.Models;

namespace WebApiVylex.Repository.Interface
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<Avaliacao>> GetAllAsync();
        Task<Avaliacao> GetByIdAsync(int id);
        Task AddAsync(Avaliacao avaliacao);
        Task UpdateAsync(Avaliacao avaliacao);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
