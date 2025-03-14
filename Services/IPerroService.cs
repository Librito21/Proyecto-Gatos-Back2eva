using Models;

namespace ProtectoraAPI.Services
{
    public interface IPerroService
    {
        Task<List<Perro>> GetAllAsync();
        Task<Perro?> GetByIdAsync(int id);
        Task AddAsync(Perro perro);
        Task UpdateAsync(Perro perro);
        Task DeleteAsync(int id);
    }
}
