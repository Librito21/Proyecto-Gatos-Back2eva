using Microsoft.Data.SqlClient;
using Models;

namespace ProtectoraAPI.Repositories
{
    public class ProtectoraRepository : IProtectoraRepository
    {
        private readonly string _connectionString;

        public ProtectoraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Protectora>> GetAllAsync()
        {
            var protectoras = new List<Protectora>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Protectora";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var protectora = new Protectora
                            {
                                Id_Protectora = reader.GetInt32(0),
                                Nombre_Protectora = reader.GetString(1),
                                Direccion = reader.GetString(2),
                                Telefono = reader.GetString(3),
                                Email = reader.GetString(4)
                            };

                            protectoras.Add(protectora);
                        }
                    }
                }
            }
            return protectoras;
        }

        public async Task<Protectora?> GetByIdAsync(int id)
        {
            Protectora? protectora = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Protectora WHERE Id_Protectora = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            protectora = new Protectora
                            {
                                Id_Protectora = reader.GetInt32(0),
                                Nombre_Protectora = reader.GetString(1),
                                Direccion = reader.GetString(2),
                                Telefono = reader.GetString(3),
                                Email = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return protectora;
        }

        public async Task AddAsync(Protectora protectora)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Protectora (Nombre_Protectora, Direccion, Telefono, Email) VALUES (@Nombre_Protectora, @Direccion, @Telefono, @Email)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre_Protectora", protectora.Nombre_Protectora);
                    command.Parameters.AddWithValue("@Direccion", protectora.Direccion);
                    command.Parameters.AddWithValue("@Telefono", protectora.Telefono);
                    command.Parameters.AddWithValue("@Email", protectora.Email);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Protectora protectora)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Protectora SET Nombre_Protectora = @Nombre_Protectora, Direccion = @Direccion, Telefono = @Telefono, Email = @Email WHERE Id_Protectora = @Id_Protectora";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Protectora", protectora.Id_Protectora);
                    command.Parameters.AddWithValue("@Nombre_Protectora", protectora.Nombre_Protectora);
                    command.Parameters.AddWithValue("@Direccion", protectora.Direccion);
                    command.Parameters.AddWithValue("@Telefono", protectora.Telefono);
                    command.Parameters.AddWithValue("@Email", protectora.Email);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Protectora WHERE Id_Protectora = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
