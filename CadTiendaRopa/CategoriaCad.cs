using System.Data.SqlClient;

namespace CadTiendaRopa
{
    public class CategoriaCad
    {
        public List<Categoria> listar()
        {
            var lista = new List<Categoria>();

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand("SELECT * FROM Categorias WHERE Eliminado=0 ORDER BY Nombre", conexion);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var categoria = new Categoria
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "" : reader.GetString(reader.GetOrdinal("Descripcion")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                        lista.Add(categoria);
                    }
                }
            }

            return lista;
        }

        public int crear(Categoria categoria)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"INSERT INTO Categorias (Nombre, Descripcion, Eliminado) 
                                               VALUES (@nombre, @descripcion, 0)", conexion);
                comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                comando.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(categoria.Descripcion) ? (object)DBNull.Value : categoria.Descripcion);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }

        public int actualizar(Categoria categoria)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"UPDATE Categorias SET 
                                               Nombre=@nombre, 
                                               Descripcion=@descripcion 
                                               WHERE Id=@id", conexion);
                comando.Parameters.AddWithValue("@id", categoria.Id);
                comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
                comando.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(categoria.Descripcion) ? (object)DBNull.Value : categoria.Descripcion);

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
                var comando = new SqlCommand("UPDATE Categorias SET Eliminado=1 WHERE Id=@id", conexion);
                comando.Parameters.AddWithValue("@id", id);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }
    }
}