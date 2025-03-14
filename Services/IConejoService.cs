using Models;

namespace ProtectoraAPI.Services
{
    public interface IConejoService
    {
        Task<List<Conejo>> GetAllAsync();
        Task<Conejo?> GetByIdAsync(int id);
        Task AddAsync(Conejo conejo);
        Task UpdateAsync(Conejo conejo);
        Task DeleteAsync(int id);
    }
}