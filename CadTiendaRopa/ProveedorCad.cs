using System.Data;
using System.Data.SqlClient;

namespace CadTiendaRopa
{
    public class ProveedorCad
    {
        public List<Proveedor> listar()
        {
            var lista = new List<Proveedor>();

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand("SELECT * FROM Proveedores WHERE Eliminado=0 ORDER BY Nombre", conexion);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var proveedor = new Proveedor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Contacto = reader.IsDBNull(reader.GetOrdinal("Contacto")) ? "" : reader.GetString(reader.GetOrdinal("Contacto")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? "" : reader.GetString(reader.GetOrdinal("Telefono")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                        lista.Add(proveedor);
                    }
                }
            }

            return lista;
        }

        public int crear(Proveedor proveedor)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"INSERT INTO Proveedores (Nombre, Contacto, Telefono, Eliminado) 
                                               VALUES (@nombre, @contacto, @telefono, 0)", conexion);
                comando.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                comando.Parameters.AddWithValue("@contacto", string.IsNullOrEmpty(proveedor.Contacto) ? (object)DBNull.Value : proveedor.Contacto);
                comando.Parameters.AddWithValue("@telefono", string.IsNullOrEmpty(proveedor.Telefono) ? (object)DBNull.Value : proveedor.Telefono);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }

        public int actualizar(Proveedor proveedor)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"UPDATE Proveedores SET 
                                               Nombre=@nombre, 
                                               Contacto=@contacto, 
                                               Telefono=@telefono 
                                               WHERE Id=@id", conexion);
                comando.Parameters.AddWithValue("@id", proveedor.Id);
                comando.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                comando.Parameters.AddWithValue("@contacto", string.IsNullOrEmpty(proveedor.Contacto) ? (object)DBNull.Value : proveedor.Contacto);
                comando.Parameters.AddWithValue("@telefono", string.IsNullOrEmpty(proveedor.Telefono) ? (object)DBNull.Value : proveedor.Telefono);

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
                var comando = new SqlCommand("UPDATE Proveedores SET Eliminado=1 WHERE Id=@id", conexion);
                comando.Parameters.AddWithValue("@id", id);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }
    }
}