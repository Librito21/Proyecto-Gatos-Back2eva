using Models;

namespace ProtectoraAPI.Repositories
{
    public interface IDeseadoRepository
    {
        Task<List<Deseado>> GetAllAsync();
        Task<Deseado?> GetByIdAsync(int id);
        Task<int> AddAsync(Deseado deseado);
        Task DeleteAsync(int id);
    }
}
