using Models;
using ProtectoraAPI.Repositories;

namespace ProtectoraAPI.Services
{
    public class ConejoService : IConejoService
    {
        private readonly IConejoRepository _repository;

        public ConejoService(IConejoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Conejo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Conejo?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Conejo conejo)
        {
            await _repository.AddAsync(conejo);
        }

        public async Task UpdateAsync(Conejo conejo)
        {
            await _repository.UpdateAsync(conejo);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}