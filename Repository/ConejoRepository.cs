using Microsoft.Data.SqlClient;
using Models;

namespace ProtectoraAPI.Repositories
{
    public class ConejoRepository : IConejoRepository
    {
        private readonly string _connectionString;

        public ConejoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Conejo>> GetAllAsync()
        {
            var conejos = new List<Conejo>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Conejo";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var conejo = new Conejo
                            {
                                Id_Conejo = reader.GetInt32(0),
                                Id_Protectora = reader.GetInt32(1),
                                Nombre_Conejo = reader.GetString(2),
                                Raza = reader.GetString(3),
                                Edad = reader.GetInt32(4),
                                Sexo = reader.GetString(5),
                                Imagen_Conejo = reader.GetString(6)
                            };

                            conejos.Add(conejo);
                        }
                    }
                }
            }
            return conejos;
        }

        public async Task<Conejo?> GetByIdAsync(int id)
        {
            Conejo? conejo = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Conejo WHERE Id_Conejo = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            conejo = new Conejo
                            {
                                Id_Conejo = reader.GetInt32(0),
                                Id_Protectora = reader.GetInt32(1),
                                Nombre_Conejo = reader.GetString(2),
                                Raza = reader.GetString(3),
                                Edad = reader.GetInt32(4),
                                Sexo = reader.GetString(5),
                                Imagen_Conejo = reader.GetString(6)
                            };
                        }
                    }
                }
            }
            return conejo;
        }

        public async Task AddAsync(Conejo conejo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Conejo (Id_Protectora, Nombre_Conejo, Raza, Edad, Sexo, Imagen_Conejo) " +
                               "VALUES (@Id_Protectora, @Nombre_Conejo, @Raza, @Edad, @Sexo, @Imagen_Conejo)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Protectora", conejo.Id_Protectora);
                    command.Parameters.AddWithValue("@Nombre_Conejo", conejo.Nombre_Conejo);
                    command.Parameters.AddWithValue("@Raza", conejo.Raza);
                    command.Parameters.AddWithValue("@Edad", conejo.Edad);
                    command.Parameters.AddWithValue("@Sexo", conejo.Sexo);
                    command.Parameters.AddWithValue("@Imagen_Conejo", conejo.Imagen_Conejo);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Conejo conejo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Conejo SET Id_Protectora = @Id_Protectora, Nombre_Conejo = @Nombre_Conejo, Raza = @Raza, Edad = @Edad, Sexo = @Sexo, Imagen_Conejo = @Imagen_Conejo WHERE Id_Conejo = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", conejo.Id_Conejo);
                    command.Parameters.AddWithValue("@Id_Protectora", conejo.Id_Protectora);
                    command.Parameters.AddWithValue("@Nombre_Conejo", conejo.Nombre_Conejo);
                    command.Parameters.AddWithValue("@Raza", conejo.Raza);
                    command.Parameters.AddWithValue("@Edad", conejo.Edad);
                    command.Parameters.AddWithValue("@Sexo", conejo.Sexo);
                    command.Parameters.AddWithValue("@Imagen_Conejo", conejo.Imagen_Conejo);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Conejo WHERE Id_Conejo = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}