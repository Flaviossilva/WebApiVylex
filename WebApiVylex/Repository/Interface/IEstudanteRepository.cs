using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiVylex.Models;
namespace WebApiVylex.Repository.Interface
{
    public interface IEstudanteRepository
    {
        Task<IEnumerable<Estudante>> GetAllAsync();
        Task<Estudante> GetByIdAsync(int id);
        Task AddAsync(Estudante estudante);
        Task UpdateAsync(Estudante estudante);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }

}
