using System.Data;
using System.Data.SqlClient;

namespace CadTiendaRopa
{
    public class ClienteCad
    {
        public List<Cliente> listar()
        {
            var lista = new List<Cliente>();

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand("SELECT * FROM Clientes WHERE Eliminado=0 ORDER BY Nombre", conexion);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            CI = reader.IsDBNull(reader.GetOrdinal("CI")) ? "" : reader.GetString(reader.GetOrdinal("CI")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? "" : reader.GetString(reader.GetOrdinal("Telefono")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                        lista.Add(cliente);
                    }
                }
            }

            return lista;
        }

        public int crear(Cliente cliente)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"INSERT INTO Clientes (Nombre, CI, Telefono, Eliminado) 
                                               VALUES (@nombre, @ci, @telefono, 0)", conexion);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@ci", string.IsNullOrEmpty(cliente.CI) ? (object)DBNull.Value : cliente.CI);
                comando.Parameters.AddWithValue("@telefono", string.IsNullOrEmpty(cliente.Telefono) ? (object)DBNull.Value : cliente.Telefono);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }

        public int actualizar(Cliente cliente)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"UPDATE Clientes SET 
                                               Nombre=@nombre, 
                                               CI=@ci, 
                                               Telefono=@telefono 
                                               WHERE Id=@id", conexion);
                comando.Parameters.AddWithValue("@id", cliente.Id);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@ci", string.IsNullOrEmpty(cliente.CI) ? (object)DBNull.Value : cliente.CI);
                comando.Parameters.AddWithValue("@telefono", string.IsNullOrEmpty(cliente.Telefono) ? (object)DBNull.Value : cliente.Telefono);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }

        public int eliminar(int id)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand("UPDATE Clientes SET Eliminado=1 WHERE Id=@id", conexion);
                comando.Parameters.AddWithValue("@id", id);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }

        public List<Cliente> buscar(string texto)
        {
            var lista = new List<Cliente>();

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"SELECT * FROM Clientes 
                                               WHERE Eliminado=0 AND 
                                               (Nombre LIKE @texto OR CI LIKE @texto OR Telefono LIKE @texto)
                                               ORDER BY Nombre", conexion);
                comando.Parameters.AddWithValue("@texto", $"%{texto}%");

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            CI = reader.IsDBNull(reader.GetOrdinal("CI")) ? "" : reader.GetString(reader.GetOrdinal("CI")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? "" : reader.GetString(reader.GetOrdinal("Telefono")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                        lista.Add(cliente);
                    }
                }
            }

            return lista;
        }
    }
}