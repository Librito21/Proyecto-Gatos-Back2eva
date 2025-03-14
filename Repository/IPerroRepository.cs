using Models;

namespace ProtectoraAPI.Repositories
{
    public interface IPerroRepository
    {
        Task<List<Perro>> GetAllAsync();
        Task<Perro?> GetByIdAsync(int id);
        Task AddAsync(Perro perro);
        Task UpdateAsync(Perro perro);
        Task DeleteAsync(int id);
    }
}
