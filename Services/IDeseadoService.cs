using Models;

namespace ProtectoraAPI.Services
{
    public interface IDeseadoService
    {
        Task<List<Deseado>> GetAllAsync();
        Task<Deseado?> GetByIdAsync(int id);
        Task AddAsync(Deseado deseado);
        Task DeleteAsync(int id);
    }
}
