
using Microsoft.Data.SqlClient;

namespace RestauranteAPI.Repositories
{
    public class PostreRepository : IPostreRepository
    {
        private readonly string _connectionString;

        public PostreRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Postre>> GetAllAsync()
        {
            var Postres = new List<Postre>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, Precio, Calorias, ConAzucar FROM Postre";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var Postre = new Postre
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = (double)reader.GetDecimal(2),
                                Calorias = reader.GetInt32(3),
                                ConAzucar = reader.GetBoolean(4)
                            }; 

                            Postres.Add(Postre);
                        }
                    }
                }
            }
            return Postres;
        }

        public async Task<Postre> GetByIdAsync(int id)
        {
            Postre Postre = null;

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
                            Postre = new Postre
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
            return Postre;
        }

        public async Task AddAsync(Postre Postre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Postre (Nombre, Precio, Calorias, ConAzucar) VALUES (@Nombre, @Precio, @Calorias, @ConAzucar)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Postre.Nombre);
                    command.Parameters.AddWithValue("@Precio", Postre.Precio);
                    command.Parameters.AddWithValue("@Calorias", Postre.Calorias);
                    command.Parameters.AddWithValue("@ConAzucar", Postre.ConAzucar);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Postre Postres)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Calorias = @Calorias, ConAzucar = @ConAzucar WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Postres.Id);
                    command.Parameters.AddWithValue("@Nombre", Postres.Nombre);
                    command.Parameters.AddWithValue("@Precio", Postres.Precio);
                    command.Parameters.AddWithValue("@Calorias", Postres.Calorias);
                    command.Parameters.AddWithValue("@ConAzucar", Postres.ConAzucar);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Postres WHERE Id = @Id";
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
                    // Parámetros para el primer plato
                    command.Parameters.AddWithValue("@Nombre1", "Turrón");
                    command.Parameters.AddWithValue("@Precio1", 12.50);
                    command.Parameters.AddWithValue("@Calorias1", 350);
                    command.Parameters.AddWithValue("@ConAzucar1", "True");

                    // Parámetros para el segundo plato
                    command.Parameters.AddWithValue("@Nombre2", "Mazapán");
                    command.Parameters.AddWithValue("@Precio2", 10.00);
                    command.Parameters.AddWithValue("@Calorias2", 180);
                    command.Parameters.AddWithValue("@ConAzucar2", "False");

                    await command.ExecuteNonQueryAsync();
                }
            }
        }


    }

}