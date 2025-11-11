using System.Data;
using System.Data.SqlClient;

namespace CadTiendaRopa
{
    public class VentaCad
    {
        public List<Venta> listar()
        {
            var lista = new List<Venta>();

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                var comando = new SqlCommand(@"SELECT v.*, e.Nombre as EmpleadoNombre, c.Nombre as ClienteNombre 
                                               FROM Ventas v
                                               INNER JOIN Empleados e ON v.EmpleadoId = e.Id
                                               INNER JOIN Clientes c ON v.ClienteId = c.Id
                                               WHERE v.Eliminado=0 
                                               ORDER BY v.Fecha DESC", conexion);

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var venta = new Venta
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                            Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                            EmpleadoId = reader.GetInt32(reader.GetOrdinal("EmpleadoId")),
                            ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                            EmpleadoNombre = reader.GetString(reader.GetOrdinal("EmpleadoNombre")),
                            ClienteNombre = reader.GetString(reader.GetOrdinal("ClienteNombre")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                        lista.Add(venta);
                    }
                }
            }

            return lista;
        }

        public Venta obtenerPorId(int id)
        {
            Venta venta = null;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                
                // Obtener la venta
                var comando = new SqlCommand(@"SELECT v.*, e.Nombre as EmpleadoNombre, c.Nombre as ClienteNombre 
                                               FROM Ventas v
                                               INNER JOIN Empleados e ON v.EmpleadoId = e.Id
                                               INNER JOIN Clientes c ON v.ClienteId = c.Id
                                               WHERE v.Id=@id AND v.Eliminado=0", conexion);
                comando.Parameters.AddWithValue("@id", id);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        venta = new Venta
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                            Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                            EmpleadoId = reader.GetInt32(reader.GetOrdinal("EmpleadoId")),
                            ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                            EmpleadoNombre = reader.GetString(reader.GetOrdinal("EmpleadoNombre")),
                            ClienteNombre = reader.GetString(reader.GetOrdinal("ClienteNombre")),
                            Eliminado = reader.GetBoolean(reader.GetOrdinal("Eliminado"))
                        };
                    }
                }

                // Obtener los detalles
                if (venta != null)
                {
                    var cmdDetalle = new SqlCommand(@"SELECT dv.*, p.Nombre as ProductoNombre, p.Talla, p.Color 
                                                      FROM DetalleVenta dv
                                                      INNER JOIN Productos p ON dv.ProductoId = p.Id
                                                      WHERE dv.VentaId=@ventaId", conexion);
                    cmdDetalle.Parameters.AddWithValue("@ventaId", id);

                    using (var reader = cmdDetalle.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var detalle = new DetalleVenta
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                VentaId = reader.GetInt32(reader.GetOrdinal("VentaId")),
                                ProductoId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                Cantidad = reader.GetInt32(reader.GetOrdinal("Cantidad")),
                                PrecioUnitario = reader.GetDecimal(reader.GetOrdinal("PrecioUnitario")),
                                ProductoNombre = reader.GetString(reader.GetOrdinal("ProductoNombre")),
                                ProductoTalla = reader.GetString(reader.GetOrdinal("Talla")),
                                ProductoColor = reader.GetString(reader.GetOrdinal("Color"))
                            };
                            venta.Detalles.Add(detalle);
                        }
                    }
                }
            }

            return venta;
        }

        public int crear(Venta venta)
        {
            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // Insertar la venta
                        var cmdVenta = new SqlCommand(@"INSERT INTO Ventas (Fecha, Total, EmpleadoId, ClienteId, Eliminado) 
                                                        VALUES (@fecha, @total, @empleadoId, @clienteId, 0);
                                                        SELECT CAST(SCOPE_IDENTITY() as int)", conexion, transaccion);
                        cmdVenta.Parameters.AddWithValue("@fecha", venta.Fecha);
                        cmdVenta.Parameters.AddWithValue("@total", venta.Total);
                        cmdVenta.Parameters.AddWithValue("@empleadoId", venta.EmpleadoId);
                        cmdVenta.Parameters.AddWithValue("@clienteId", venta.ClienteId);

                        int ventaId = (int)cmdVenta.ExecuteScalar();

                        // Insertar los detalles y actualizar stock
                        foreach (var detalle in venta.Detalles)
                        {
                            var cmdDetalle = new SqlCommand(@"INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, PrecioUnitario) 
                                                              VALUES (@ventaId, @productoId, @cantidad, @precioUnitario)", 
                                                              conexion, transaccion);
                            cmdDetalle.Parameters.AddWithValue("@ventaId", ventaId);
                            cmdDetalle.Parameters.AddWithValue("@productoId", detalle.ProductoId);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@precioUnitario", detalle.PrecioUnitario);
                            cmdDetalle.ExecuteNonQuery();

                            // Actualizar stock del producto (RESTAR)
                            var cmdStock = new SqlCommand(@"UPDATE Productos 
                                                            SET Stock = Stock - @cantidad 
                                                            WHERE Id = @productoId", conexion, transaccion);
                            cmdStock.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdStock.Parameters.AddWithValue("@productoId", detalle.ProductoId);
                            cmdStock.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return ventaId;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public int eliminar(int id)
        {
            int resultado;

            using (var conexion = new SqlConnection(Util.conexion))
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // Obtener los detalles antes de eliminar para restaurar stock
                        var cmdObtenerDetalles = new SqlCommand("SELECT ProductoId, Cantidad FROM DetalleVenta WHERE VentaId=@ventaId", 
                                                                conexion, transaccion);
                        cmdObtenerDetalles.Parameters.AddWithValue("@ventaId", id);

                        var detalles = new List<(int ProductoId, int Cantidad)>();
                        using (var reader = cmdObtenerDetalles.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                detalles.Add((reader.GetInt32(0), reader.GetInt32(1)));
                            }
                        }

                        // Restaurar stock
                        foreach (var detalle in detalles)
                        {
                            var cmdStock = new SqlCommand(@"UPDATE Productos 
                                                            SET Stock = Stock + @cantidad 
                                                            WHERE Id = @productoId", conexion, transaccion);
                            cmdStock.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdStock.Parameters.AddWithValue("@productoId", detalle.ProductoId);
                            cmdStock.ExecuteNonQuery();
                        }

                        // Eliminar la venta (lógico)
                        var cmdEliminar = new SqlCommand("UPDATE Ventas SET Eliminado=1 WHERE Id=@id", conexion, transaccion);
                        cmdEliminar.Parameters.AddWithValue("@id", id);
                        resultado = cmdEliminar.ExecuteNonQuery();

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }

            return resultado;
        }
    }
}