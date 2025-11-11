using CadTiendaRopa;

namespace ClnTiendaRopa
{
    public class VentaCln
    {
        public static List<Venta> listar()
        {
            return new VentaCad().listar();
        }

        public static Venta obtenerPorId(int id)
        {
            return new VentaCad().obtenerPorId(id);
        }

        public static int crear(Venta venta)
        {
            // Validaciones de negocio
            if (venta.Detalles.Count == 0)
                throw new Exception("La venta debe tener al menos un producto");

            if (venta.Total <= 0)
                throw new Exception("El total de la venta debe ser mayor a 0");

            return new VentaCad().crear(venta);
        }

        public static int eliminar(int id)
        {
            return new VentaCad().eliminar(id);
        }
    }
}