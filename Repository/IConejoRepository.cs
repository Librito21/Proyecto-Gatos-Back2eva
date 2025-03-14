using Models;

namespace ProtectoraAPI.Repositories
{
    public interface IConejoRepository
    {
        Task<List<Conejo>> GetAllAsync();
        Task<Conejo?> GetByIdAsync(int id);
        Task AddAsync(Conejo conejo);
        Task UpdateAsync(Conejo conejo);
        Task DeleteAsync(int id);
    }
}