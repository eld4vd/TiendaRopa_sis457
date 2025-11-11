using System.Data;
using System.Data.SqlClient;

namespace CadTiendaRopa
{
    public class ProductoCad
    {
        private static int? GetCategoriaIdByNombre(SqlConnection cn, SqlTransaction? tx, string nombreCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombreCategoria)) return null;

            using var cmd = new SqlCommand(@"
                SELECT Id FROM Categorias WHERE Eliminado=0 AND Nombre=@n;
                ", cn, tx);
            cmd.Parameters.AddWithValue("@n", nombreCategoria.Trim());
            var res = cmd.ExecuteScalar();
            if (res != null && res != DBNull.Value) return (int)res;

            using var cmdIns = new SqlCommand(@"
                INSERT INTO Categorias (Nombre, Descripcion, Eliminado) VALUES (@n, @d, 0);
                SELECT SCOPE_IDENTITY();
                ", cn, tx);
            cmdIns.Parameters.AddWithValue("@n", nombreCategoria.Trim());
            cmdIns.Parameters.AddWithValue("@d", (object)DBNull.Value);
            var id = cmdIns.ExecuteScalar();
            return id == null || id == DBNull.Value ? null : Convert.ToInt32(id);
        }

        // Listar todos los productos activos
        public List<Producto> listar()
        {
            var lista = new List<Producto>();
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();
            using var cmd = new SqlCommand(@"
                SELECT p.*, c.Nombre AS CategoriaNombre
                FROM Productos p
                LEFT JOIN Categorias c ON p.CategoriaId = c.Id
                WHERE p.Eliminado = 0
                ORDER BY p.Nombre;", cn);

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lista.Add(new Producto
                {
                    Id = r.GetInt32(r.GetOrdinal("Id")),
                    Nombre = r.GetString(r.GetOrdinal("Nombre")),
                    Talla = r.GetString(r.GetOrdinal("Talla")),
                    Color = r.GetString(r.GetOrdinal("Color")),
                    Precio = r.GetDecimal(r.GetOrdinal("Precio")),
                    Stock = r.GetInt32(r.GetOrdinal("Stock")),
                    CategoriaId = r.IsDBNull(r.GetOrdinal("CategoriaId")) ? null : r.GetInt32(r.GetOrdinal("CategoriaId")),
                    Categoria = r.IsDBNull(r.GetOrdinal("CategoriaNombre")) ? "" : r.GetString(r.GetOrdinal("CategoriaNombre")),
                    EsDeProveedor = !r.IsDBNull(r.GetOrdinal("EsDeProveedor")) && r.GetBoolean(r.GetOrdinal("EsDeProveedor")),
                    // 🔥 NUEVO:
                    ImagenUrl = r.IsDBNull(r.GetOrdinal("ImagenUrl")) ? null : r.GetString(r.GetOrdinal("ImagenUrl")),
                    Eliminado = r.GetBoolean(r.GetOrdinal("Eliminado"))
                });
            }
            return lista;
        }

        // Obtener por ID
        public Producto? obtenerPorId(int id)
        {
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();
            using var cmd = new SqlCommand(@"
                SELECT p.*, c.Nombre AS CategoriaNombre
                FROM Productos p
                LEFT JOIN Categorias c ON p.CategoriaId = c.Id
                WHERE p.Id=@id AND p.Eliminado=0;", cn);
            cmd.Parameters.AddWithValue("@id", id);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            return new Producto
            {
                Id = r.GetInt32(r.GetOrdinal("Id")),
                Nombre = r.GetString(r.GetOrdinal("Nombre")),
                Talla = r.GetString(r.GetOrdinal("Talla")),
                Color = r.GetString(r.GetOrdinal("Color")),
                Precio = r.GetDecimal(r.GetOrdinal("Precio")),
                Stock = r.GetInt32(r.GetOrdinal("Stock")),
                CategoriaId = r.IsDBNull(r.GetOrdinal("CategoriaId")) ? null : r.GetInt32(r.GetOrdinal("CategoriaId")),
                Categoria = r.IsDBNull(r.GetOrdinal("CategoriaNombre")) ? "" : r.GetString(r.GetOrdinal("CategoriaNombre")),
                EsDeProveedor = !r.IsDBNull(r.GetOrdinal("EsDeProveedor")) && r.GetBoolean(r.GetOrdinal("EsDeProveedor")),
                Eliminado = r.GetBoolean(r.GetOrdinal("Eliminado"))
            };
        }

        // Crear nuevo producto
        public int crear(Producto p)
        {
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();
            using var tx = cn.BeginTransaction();

            try
            {
                var categoriaId = GetCategoriaIdByNombre(cn, tx, p.Categoria ?? "");

                using var cmd = new SqlCommand(@"
                    INSERT INTO Productos (Nombre, Talla, Color, Precio, Stock, CategoriaId, EsDeProveedor, ImagenUrl, Eliminado)
                    VALUES (@n,@t,@c,@pr,@s,@cat,@prov,@img,0);", cn, tx);

                cmd.Parameters.AddWithValue("@n", p.Nombre);
                cmd.Parameters.AddWithValue("@t", p.Talla);
                cmd.Parameters.AddWithValue("@c", p.Color);
                cmd.Parameters.AddWithValue("@pr", p.Precio);
                cmd.Parameters.AddWithValue("@s", p.Stock);
                cmd.Parameters.AddWithValue("@cat", (object?)categoriaId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@prov", p.EsDeProveedor);
                cmd.Parameters.AddWithValue("@img", (object?)p.ImagenUrl ?? DBNull.Value);
                var res = cmd.ExecuteNonQuery();

                tx.Commit();
                return res;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        // Actualizar producto
        public int actualizar(Producto p)
        {
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();
            using var tx = cn.BeginTransaction();

            try
            {
                var categoriaId = GetCategoriaIdByNombre(cn, tx, p.Categoria ?? "");

                using var cmd = new SqlCommand(@"
                    UPDATE Productos SET
                        Nombre=@n, Talla=@t, Color=@c, Precio=@pr, Stock=@s,
                        CategoriaId=@cat, EsDeProveedor=@prov, ImagenUrl=@img
                    WHERE Id=@id;", cn, tx);
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@n", p.Nombre);
                cmd.Parameters.AddWithValue("@t", p.Talla);
                cmd.Parameters.AddWithValue("@c", p.Color);
                cmd.Parameters.AddWithValue("@pr", p.Precio);
                cmd.Parameters.AddWithValue("@s", p.Stock);
                cmd.Parameters.AddWithValue("@cat", (object?)categoriaId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@prov", p.EsDeProveedor);
                cmd.Parameters.AddWithValue("@img", (object?)p.ImagenUrl ?? DBNull.Value);

                var res = cmd.ExecuteNonQuery();
                tx.Commit();
                return res;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        // Eliminar (lógico)
        public int eliminar(int id)
        {
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();
            using var cmd = new SqlCommand("UPDATE Productos SET Eliminado=1 WHERE Id=@id;", cn);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        // Buscar por nombre
        public List<Producto> buscar(string texto)
        {
            var lista = new List<Producto>();
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();
            using var cmd = new SqlCommand(@"
                SELECT p.*, c.Nombre AS CategoriaNombre
                FROM Productos p
                LEFT JOIN Categorias c ON p.CategoriaId = c.Id
                WHERE p.Eliminado=0 AND
                      (p.Nombre LIKE @t OR c.Nombre LIKE @t OR p.Color LIKE @t)
                ORDER BY p.Nombre;", cn);
            cmd.Parameters.AddWithValue("@t", $"%{texto}%");

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lista.Add(new Producto
                {
                    Id = r.GetInt32(r.GetOrdinal("Id")),
                    Nombre = r.GetString(r.GetOrdinal("Nombre")),
                    Talla = r.GetString(r.GetOrdinal("Talla")),
                    Color = r.GetString(r.GetOrdinal("Color")),
                    Precio = r.GetDecimal(r.GetOrdinal("Precio")),
                    Stock = r.GetInt32(r.GetOrdinal("Stock")),
                    CategoriaId = r.IsDBNull(r.GetOrdinal("CategoriaId")) ? null : r.GetInt32(r.GetOrdinal("CategoriaId")),
                    Categoria = r.IsDBNull(r.GetOrdinal("CategoriaNombre")) ? "" : r.GetString(r.GetOrdinal("CategoriaNombre")),
                    EsDeProveedor = !r.IsDBNull(r.GetOrdinal("EsDeProveedor")) && r.GetBoolean(r.GetOrdinal("EsDeProveedor")),
                    Eliminado = r.GetBoolean(r.GetOrdinal("Eliminado"))
                });
            }
            return lista;
        }
    }
}