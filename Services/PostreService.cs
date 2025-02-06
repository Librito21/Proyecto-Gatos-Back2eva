
using Microsoft.Data.SqlClient;

namespace RestauranteAPI.Services
{
    public class PostreService : IPostreService
    {
        private readonly string _connectionString;

        public PostreService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Postre>> GetAllAsync()
        {
            var bebidas = new List<Postre>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, Precio, Ingredientes FROM Postre";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var postre = new Postre
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = (double)reader.GetDecimal(2),
                                Calorias = reader.GetInt32(3),
                                ConAzucar = reader.GetBoolean(4)
                            }; 

                            bebidas.Add(postre);
                        }
                    }
                }
            }
            return bebidas;
        }

        public async Task<Postre> GetByIdAsync(int id)
        {
            Postre postre = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, Precio, Calorias, ConAzucar FROM Postre WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            postre = new Postre
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetDouble(2),
                                Calorias = reader.GetInt32(3),
                                ConAzucar = reader.GetBoolean(4)
                            };
                        }
                    }
                }
            }
            return postre;
        }

        public async Task AddAsync(Postre postre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Postre (Nombre, Precio, Calorias, ConAzucar) VALUES (@Nombre, @Precio, @Calorias, @ConAzucar)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", postre.Nombre);
                    command.Parameters.AddWithValue("@Precio", postre.Precio);
                    command.Parameters.AddWithValue("@Calorias", postre.Calorias);
                    command.Parameters.AddWithValue("@ConAzucar", postre.ConAzucar);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Postre postre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Calorias = @Calorias, ConAzucar = @ConAzucar WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", postre.Id);
                    command.Parameters.AddWithValue("@Nombre", postre.Nombre);
                    command.Parameters.AddWithValue("@Precio", postre.Precio);
                    command.Parameters.AddWithValue("@Calorias", postre.Calorias);
                    command.Parameters.AddWithValue("@ConAzucar", postre.ConAzucar);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Postre WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task InicializarDatosAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Comando SQL para insertar datos iniciales
                var query = @"
                    INSERT INTO Postre (Nombre, Precio, Calorias, ConAzucar)
                    VALUES 
                    (@Nombre1, @Precio1, @Calorias1, @ConAzucar1),
                    (@Nombre2, @Precio2, @Calorias2, @ConAzucar2)";

                using (var command = new SqlCommand(query, connection))
                {
                    // Parámetros para el primer postre
                    command.Parameters.AddWithValue("@Nombre1", "Flan");
                    command.Parameters.AddWithValue("@Precio1", 12.50);
                    command.Parameters.AddWithValue("@Calorias1", 150);
                    command.Parameters.AddWithValue("@ConAzucar", false);

                    // Parámetros para el segundo postre
                    command.Parameters.AddWithValue("@Nombre2", "Trufa");
                    command.Parameters.AddWithValue("@Precio2", 10.00);
                    command.Parameters.AddWithValue("@Calorias2", 300);
                    command.Parameters.AddWithValue("@ConAzucar2", true);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}