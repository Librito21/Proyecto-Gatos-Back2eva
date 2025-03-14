using System.Data.SqlClient;
using Models;
using ProtectoraAPI.Repositories;

namespace ProtectoraAPI.Services
{
    public class PerroService : IPerroService
    {
        private readonly IPerroRepository _repository;

        public PerroService(IPerroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Perro>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Perro?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Perro perro)
        {
            await _repository.AddAsync(perro);
        }

        public async Task UpdateAsync(Perro perro)
        {
            await _repository.UpdateAsync(perro);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
