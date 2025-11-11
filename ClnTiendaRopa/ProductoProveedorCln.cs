using CadTiendaRopa;

namespace ClnTiendaRopa
{
    public class ProductoProveedorCln
    {
        public static List<ProductoProveedor> listar()
        {
            return new ProductoProveedorCad().listar();
        }

        public static List<ProductoProveedor> listarPorProveedor(int proveedorId)
        {
            return new ProductoProveedorCad().listarPorProveedor(proveedorId);
        }

        public static ProductoProveedor? obtenerPorId(int id)
        {
            return new ProductoProveedorCad().obtenerPorId(id);
        }

        public static int crear(ProductoProveedor producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new Exception("El nombre del producto es obligatorio");

            if (producto.PrecioProveedor <= 0)
                throw new Exception("El precio debe ser mayor a 0");

            return new ProductoProveedorCad().crear(producto);
        }

        public static int actualizar(ProductoProveedor producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new Exception("El nombre del producto es obligatorio");

            if (producto.PrecioProveedor <= 0)
                throw new Exception("El precio debe ser mayor a 0");

            return new ProductoProveedorCad().actualizar(producto);
        }

        public static int eliminar(int id)
        {
            return new ProductoProveedorCad().eliminar(id);
        }
    }
}