using System.Data;
using System.Data.SqlClient;

namespace CadTiendaRopa
{
    public class CompraCad
    {
        public int crear(Compra compra)
        {
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();
            using var tx = cn.BeginTransaction();

            try
            {
                // 1) Insert Compra
                int compraId;
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Compras (Fecha, Total, EmpleadoId, ProveedorId, Eliminado)
                    VALUES (@f,@t,@e,@p,0);
                    SELECT SCOPE_IDENTITY();", cn, tx))
                {
                    cmd.Parameters.AddWithValue("@f", compra.Fecha);
                    cmd.Parameters.AddWithValue("@t", compra.Total);
                    cmd.Parameters.AddWithValue("@e", compra.EmpleadoId);
                    cmd.Parameters.AddWithValue("@p", compra.ProveedorId);
                    compraId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2) Por cada detalle: insert + sincronizar inventario
                foreach (var d in compra.Detalles)
                {
                    // 2.1 Insert detalle con ProductoProveedorId
                    using (var cmdDet = new SqlCommand(@"
                        INSERT INTO DetalleCompras (CompraId, ProductoProveedorId, Cantidad, PrecioUnitario)
                        VALUES (@cId, @ppId, @cant, @precio);", cn, tx))
                    {
                        cmdDet.Parameters.AddWithValue("@cId", compraId);
                        cmdDet.Parameters.AddWithValue("@ppId", d.ProductoProveedorId);
                        cmdDet.Parameters.AddWithValue("@cant", d.Cantidad);
                        cmdDet.Parameters.AddWithValue("@precio", d.PrecioUnitario);
                        cmdDet.ExecuteNonQuery();
                    }

                    // 2.2 Sincronizar con Productos
                    // Tomar datos del producto del proveedor
                    string nombre;
                    int? categoriaId;
                    using (var cmdPP = new SqlCommand(@"
                        SELECT pp.Nombre, pp.CategoriaId
                        FROM ProductosProveedor pp
                        WHERE pp.Id=@id;", cn, tx))
                    {
                        cmdPP.Parameters.AddWithValue("@id", d.ProductoProveedorId);
                        using var rd = cmdPP.ExecuteReader();
                        if (!rd.Read())
                            throw new Exception("Producto del proveedor no encontrado.");

                        nombre = rd.GetString(rd.GetOrdinal("Nombre"));
                        categoriaId = rd.IsDBNull(rd.GetOrdinal("CategoriaId")) ? null : rd.GetInt32(rd.GetOrdinal("CategoriaId"));
                    }

                    // Buscar SKU en Productos por nombre y categoría
                    int? productoId = null;
                    using (var cmdFind = new SqlCommand(@"
                        SELECT TOP 1 Id FROM Productos
                        WHERE Eliminado=0 AND Nombre=@n AND ((@cat IS NULL AND CategoriaId IS NULL) OR CategoriaId=@cat);", cn, tx))
                    {
                        cmdFind.Parameters.AddWithValue("@n", nombre);
                        cmdFind.Parameters.AddWithValue("@cat", (object?)categoriaId ?? DBNull.Value);
                        var res = cmdFind.ExecuteScalar();
                        if (res != null && res != DBNull.Value)
                            productoId = Convert.ToInt32(res);
                    }

                    // Si no existe → crear SKU
                    if (productoId == null)
                    {
                        using var cmdIns = new SqlCommand(@"
                            INSERT INTO Productos (Nombre, Talla, Color, Precio, Stock, CategoriaId, EsDeProveedor, Eliminado)
                            VALUES (@n,'UNI','N/A',@precioVenta,0,@cat,1,0);
                            SELECT SCOPE_IDENTITY();", cn, tx);
                        decimal precioVenta = d.PrecioUnitario * 1.6m;
                        cmdIns.Parameters.AddWithValue("@n", nombre);
                        cmdIns.Parameters.AddWithValue("@precioVenta", precioVenta);
                        cmdIns.Parameters.AddWithValue("@cat", (object?)categoriaId ?? DBNull.Value);
                        productoId = Convert.ToInt32(cmdIns.ExecuteScalar());
                    }

                    // 2.3 Actualizar stock del SKU
                    using (var cmdUp = new SqlCommand(@"
                        UPDATE Productos SET Stock = Stock + @cant WHERE Id=@id;", cn, tx))
                    {
                        cmdUp.Parameters.AddWithValue("@cant", d.Cantidad);
                        cmdUp.Parameters.AddWithValue("@id", productoId);
                        cmdUp.ExecuteNonQuery();
                    }
                }

                tx.Commit();
                return compraId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public List<Compra> listar()
        {
            var lista = new List<Compra>();
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();
            using var cmd = new SqlCommand(@"
                SELECT c.*, e.Nombre as EmpleadoNombre, p.Nombre as ProveedorNombre
                FROM Compras c
                INNER JOIN Empleados e ON c.EmpleadoId = e.Id
                INNER JOIN Proveedores p ON c.ProveedorId = p.Id
                WHERE c.Eliminado=0
                ORDER BY c.Fecha DESC;", cn);

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                lista.Add(new Compra
                {
                    Id = r.GetInt32(r.GetOrdinal("Id")),
                    Fecha = r.GetDateTime(r.GetOrdinal("Fecha")),
                    Total = r.GetDecimal(r.GetOrdinal("Total")),
                    EmpleadoId = r.GetInt32(r.GetOrdinal("EmpleadoId")),
                    ProveedorId = r.GetInt32(r.GetOrdinal("ProveedorId")),
                    EmpleadoNombre = r.GetString(r.GetOrdinal("EmpleadoNombre")),
                    ProveedorNombre = r.GetString(r.GetOrdinal("ProveedorNombre")),
                    Eliminado = r.GetBoolean(r.GetOrdinal("Eliminado"))
                });
            }
            return lista;
        }

        public Compra? obtenerPorId(int id)
        {
            Compra? compra = null;
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();

            using (var cmd = new SqlCommand(@"
                SELECT c.*, e.Nombre as EmpleadoNombre, p.Nombre as ProveedorNombre
                FROM Compras c
                INNER JOIN Empleados e ON c.EmpleadoId = e.Id
                INNER JOIN Proveedores p ON c.ProveedorId = p.Id
                WHERE c.Id=@id AND c.Eliminado=0;", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    compra = new Compra
                    {
                        Id = r.GetInt32(r.GetOrdinal("Id")),
                        Fecha = r.GetDateTime(r.GetOrdinal("Fecha")),
                        Total = r.GetDecimal(r.GetOrdinal("Total")),
                        EmpleadoId = r.GetInt32(r.GetOrdinal("EmpleadoId")),
                        ProveedorId = r.GetInt32(r.GetOrdinal("ProveedorId")),
                        EmpleadoNombre = r.GetString(r.GetOrdinal("EmpleadoNombre")),
                        ProveedorNombre = r.GetString(r.GetOrdinal("ProveedorNombre")),
                        Eliminado = r.GetBoolean(r.GetOrdinal("Eliminado"))
                    };
                }
            }

            if (compra != null)
            {
                compra.Detalles = new List<DetalleCompra>();
                using var cmdDet = new SqlCommand(@"
                    SELECT dc.*, pp.Nombre as ProductoNombre
                    FROM DetalleCompras dc
                    INNER JOIN ProductosProveedor pp ON dc.ProductoProveedorId = pp.Id
                    WHERE dc.CompraId=@id;", cn);
                cmdDet.Parameters.AddWithValue("@id", id);

                using var rd = cmdDet.ExecuteReader();
                while (rd.Read())
                {
                    compra.Detalles.Add(new DetalleCompra
                    {
                        Id = rd.GetInt32(rd.GetOrdinal("Id")),
                        CompraId = rd.GetInt32(rd.GetOrdinal("CompraId")),
                        ProductoProveedorId = rd.GetInt32(rd.GetOrdinal("ProductoProveedorId")),
                        ProductoNombre = rd.GetString(rd.GetOrdinal("ProductoNombre")),
                        ProductoTalla = "UNI",
                        ProductoColor = "N/A",
                        Cantidad = rd.GetInt32(rd.GetOrdinal("Cantidad")),
                        PrecioUnitario = rd.GetDecimal(rd.GetOrdinal("PrecioUnitario"))
                    });
                }
            }

            return compra;
        }

        public int eliminar(int id)
        {
            using var cn = new SqlConnection(Util.conexion);
            cn.Open();
            using var cmd = new SqlCommand("UPDATE Compras SET Eliminado=1 WHERE Id=@id;", cn);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }
    }
}