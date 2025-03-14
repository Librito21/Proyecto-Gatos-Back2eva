using Microsoft.Data.SqlClient;
using Models;

namespace ProtectoraAPI.Repositories
{
    public class PerroRepository : IPerroRepository
    {
        private readonly string _connectionString;

        public PerroRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Perro>> GetAllAsync()
        {
            var perros = new List<Perro>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Perro";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var perro = new Perro
                            {
                                Id_Perro = reader.GetInt32(0),
                                Id_Protectora = reader.GetInt32(1),
                                Nombre_Perro = reader.GetString(2),
                                Raza = reader.GetString(3),
                                Edad = reader.GetInt32(4),
                                Esterilizado = reader.GetBoolean(5),
                                Sexo = reader.GetString(6),
                                Descripcion_Perro = reader.GetString(7),
                                Imagen_Perro = reader.GetString(8)
                            };

                            perros.Add(perro);
                        }
                    }
                }
            }
            return perros;
        }

        public async Task<Perro?> GetByIdAsync(int id)
        {
            Perro? perro = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Perro WHERE Id_Perro = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            perro = new Perro
                            {
                                Id_Perro = reader.GetInt32(0),
                                Id_Protectora = reader.GetInt32(1),
                                Nombre_Perro = reader.GetString(2),
                                Raza = reader.GetString(3),
                                Edad = reader.GetInt32(4),
                                Esterilizado = reader.GetBoolean(5),
                                Sexo = reader.GetString(6),
                                Descripcion_Perro = reader.GetString(7),
                                Imagen_Perro = reader.GetString(8)
                            };
                        }
                    }
                }
            }
            return perro;
        }

        public async Task AddAsync(Perro perro)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Perro (Id_Protectora, Nombre_Perro, Raza, Edad, Esterilizado, Sexo, Descripcion_Perro, Imagen_Perro) VALUES (@Id_Protectora, @Nombre_Perro, @Raza, @Edad, @Esterilizado, @Sexo, @Descripcion_Perro, @Imagen_Perro)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Protectora", perro.Id_Protectora);
                    command.Parameters.AddWithValue("@Nombre_Perro", perro.Nombre_Perro);
                    command.Parameters.AddWithValue("@Raza", perro.Raza);
                    command.Parameters.AddWithValue("@Edad", perro.Edad);
                    command.Parameters.AddWithValue("@Esterilizado", perro.Esterilizado);
                    command.Parameters.AddWithValue("@Sexo", perro.Sexo);
                    command.Parameters.AddWithValue("@Descripcion_Perro", perro.Descripcion_Perro);
                    command.Parameters.AddWithValue("@Imagen_Perro", perro.Imagen_Perro);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Perro perro)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Perro SET Id_Protectora = @Id_Protectora, Nombre_Perro = @Nombre_Perro, Raza = @Raza, Edad = @Edad, Esterilizado = @Esterilizado, Sexo = @Sexo, Descripcion_Perro = @Descripcion_Perro, Imagen_Perro = @Imagen_Perro WHERE Id_Perro = @Id_Perro";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Perro", perro.Id_Perro);
                    command.Parameters.AddWithValue("@Id_Protectora", perro.Id_Protectora);
                    command.Parameters.AddWithValue("@Nombre_Perro", perro.Nombre_Perro);
                    command.Parameters.AddWithValue("@Raza", perro.Raza);
                    command.Parameters.AddWithValue("@Edad", perro.Edad);
                    command.Parameters.AddWithValue("@Esterilizado", perro.Esterilizado);
                    command.Parameters.AddWithValue("@Sexo", perro.Sexo);
                    command.Parameters.AddWithValue("@Descripcion_Perro", perro.Descripcion_Perro);
                    command.Parameters.AddWithValue("@Imagen_Perro", perro.Imagen_Perro);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Perro WHERE Id_Perro = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
