using System.Data.SqlClient;

namespace CadTiendaRopa
{
    public class ProductoProveedorCad
    {
        public List<ProductoProveedor> listar()
        {
            var lista = new List<ProductoProveedor>();

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"
                    SELECT pp.*, p.Nombre as ProveedorNombre, c.Nombre as CategoriaNombre
                    FROM ProductosProveedor pp
                    INNER JOIN Proveedores p ON pp.ProveedorId = p.Id
                    LEFT JOIN Categorias c ON pp.CategoriaId = c.Id
                    WHERE pp.Eliminado=0 
                    ORDER BY pp.Nombre", conexion);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new ProductoProveedor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "" : reader.GetString(reader.GetOrdinal("Descripcion")),
                            PrecioProveedor = reader.GetDecimal(reader.GetOrdinal("PrecioProveedor")),
                            ProveedorId = reader.GetInt32(reader.GetOrdinal("ProveedorId")),
                            CategoriaId = reader.IsDBNull(reader.GetOrdinal("CategoriaId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CategoriaId")),
                            ProveedorNombre = reader.GetString(reader.GetOrdinal("ProveedorNombre")),
                            CategoriaNombre = reader.IsDBNull(reader.GetOrdinal("CategoriaNombre")) ? "" : reader.GetString(reader.GetOrdinal("CategoriaNombre")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                        lista.Add(producto);
                    }
                }
            }

            return lista;
        }

        public List<ProductoProveedor> listarPorProveedor(int proveedorId)
        {
            var lista = new List<ProductoProveedor>();

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"
                    SELECT pp.*, p.Nombre as ProveedorNombre, c.Nombre as CategoriaNombre
                    FROM ProductosProveedor pp
                    INNER JOIN Proveedores p ON pp.ProveedorId = p.Id
                    LEFT JOIN Categorias c ON pp.CategoriaId = c.Id
                    WHERE pp.Eliminado=0 AND pp.ProveedorId=@proveedorId
                    ORDER BY pp.Nombre", conexion);
                comando.Parameters.AddWithValue("@proveedorId", proveedorId);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new ProductoProveedor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "" : reader.GetString(reader.GetOrdinal("Descripcion")),
                            PrecioProveedor = reader.GetDecimal(reader.GetOrdinal("PrecioProveedor")),
                            ProveedorId = reader.GetInt32(reader.GetOrdinal("ProveedorId")),
                            CategoriaId = reader.IsDBNull(reader.GetOrdinal("CategoriaId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CategoriaId")),
                            ProveedorNombre = reader.GetString(reader.GetOrdinal("ProveedorNombre")),
                            CategoriaNombre = reader.IsDBNull(reader.GetOrdinal("CategoriaNombre")) ? "" : reader.GetString(reader.GetOrdinal("CategoriaNombre")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                        lista.Add(producto);
                    }
                }
            }

            return lista;
        }

        public ProductoProveedor? obtenerPorId(int id)
        {
            ProductoProveedor? producto = null;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"
                    SELECT pp.*, p.Nombre as ProveedorNombre, c.Nombre as CategoriaNombre
                    FROM ProductosProveedor pp
                    INNER JOIN Proveedores p ON pp.ProveedorId = p.Id
                    LEFT JOIN Categorias c ON pp.CategoriaId = c.Id
                    WHERE pp.Id=@id AND pp.Eliminado=0", conexion);
                comando.Parameters.AddWithValue("@id", id);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new ProductoProveedor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? "" : reader.GetString(reader.GetOrdinal("Descripcion")),
                            PrecioProveedor = reader.GetDecimal(reader.GetOrdinal("PrecioProveedor")),
                            ProveedorId = reader.GetInt32(reader.GetOrdinal("ProveedorId")),
                            CategoriaId = reader.IsDBNull(reader.GetOrdinal("CategoriaId")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CategoriaId")),
                            ProveedorNombre = reader.GetString(reader.GetOrdinal("ProveedorNombre")),
                            CategoriaNombre = reader.IsDBNull(reader.GetOrdinal("CategoriaNombre")) ? "" : reader.GetString(reader.GetOrdinal("CategoriaNombre")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                    }
                }
            }

            return producto;
        }

        public int crear(ProductoProveedor producto)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"
                    INSERT INTO ProductosProveedor (Nombre, Descripcion, PrecioProveedor, ProveedorId, CategoriaId, Eliminado)
                    VALUES (@nombre, @descripcion, @precio, @proveedorId, @categoriaId, 0)", conexion);

                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(producto.Descripcion) ? (object)DBNull.Value : producto.Descripcion);
                comando.Parameters.AddWithValue("@precio", producto.PrecioProveedor);
                comando.Parameters.AddWithValue("@proveedorId", producto.ProveedorId);
                comando.Parameters.AddWithValue("@categoriaId", producto.CategoriaId.HasValue ? (object)producto.CategoriaId.Value : DBNull.Value);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }

        public int actualizar(ProductoProveedor producto)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"
                    UPDATE ProductosProveedor SET
                        Nombre=@nombre,
                        Descripcion=@descripcion,
                        PrecioProveedor=@precio,
                        CategoriaId=@categoriaId
                    WHERE Id=@id", conexion);

                comando.Parameters.AddWithValue("@id", producto.Id);
                comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(producto.Descripcion) ? (object)DBNull.Value : producto.Descripcion);
                comando.Parameters.AddWithValue("@precio", producto.PrecioProveedor);
                comando.Parameters.AddWithValue("@categoriaId", producto.CategoriaId.HasValue ? (object)producto.CategoriaId.Value : DBNull.Value);

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
                var comando = new SqlCommand("UPDATE ProductosProveedor SET Eliminado=1 WHERE Id=@id", conexion);
                comando.Parameters.AddWithValue("@id", id);

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }
    }
}