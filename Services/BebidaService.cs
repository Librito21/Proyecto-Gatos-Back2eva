
using Microsoft.Data.SqlClient;

namespace RestauranteAPI.Services
{
    public class BebidaService : IBebidaService
    {
        private readonly string _connectionString;

        public BebidaService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Bebida>> GetAllAsync()
        {
            var platosPrincipales = new List<Bebida>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, Precio, EsAlcoholica FROM Bebida";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var plato = new Bebida
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = (double)reader.GetDecimal(2),
                                EsAlcoholica = reader.GetBoolean(3)
                            }; 

                            platosPrincipales.Add(plato);
                        }
                    }
                }
            }
            return platosPrincipales;
        }

        public async Task<Bebida> GetByIdAsync(int id)
        {
            Bebida bebida = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, Precio, EsAlcoholica FROM Bebida WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            bebida = new Bebida
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetDouble(2),
                                EsAlcoholica = reader.GetBoolean(3)
                            };
                        }
                    }
                }
            }
            return bebida;
        }

        public async Task AddAsync(Bebida bebida)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Bebida (Nombre, Precio, EsAlcoholica) VALUES (@Nombre, @Precio, @EsAlcoholica)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", bebida.Nombre);
                    command.Parameters.AddWithValue("@Precio", bebida.Precio);
                    command.Parameters.AddWithValue("@EsAlcoholica", bebida.EsAlcoholica);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Bebida bebida)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, EsAlcoholica = @EsAlcoholica WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", bebida.Id);
                    command.Parameters.AddWithValue("@Nombre", bebida.Nombre);
                    command.Parameters.AddWithValue("@Precio", bebida.Precio);
                    command.Parameters.AddWithValue("@EsAlcoholica", bebida.EsAlcoholica);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Bebida WHERE Id = @Id";
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
                    INSERT INTO Bebida (Nombre, Precio, EsAlcoholica)
                    VALUES 
                    (@Nombre1, @Precio1, @EsAlcoholica1),
                    (@Nombre2, @Precio2, @EsAlcoholica2)";

                using (var command = new SqlCommand(query, connection))
                {
                    // Parámetros para el primer plato
                    command.Parameters.AddWithValue("@Nombre1", "Plato combinado");
                    command.Parameters.AddWithValue("@Precio1", 12.50);
                    command.Parameters.AddWithValue("@EsAlcoholica1", "Pollo, patatas, tomate");

                    // Parámetros para el segundo plato
                    command.Parameters.AddWithValue("@Nombre2", "Plato vegetariano");
                    command.Parameters.AddWithValue("@Precio2", 10.00);
                    command.Parameters.AddWithValue("@EsAlcoholica2", "Tofu, verduras, arroz");

                    await command.ExecuteNonQueryAsync();
                }
            }
        }


    }

}