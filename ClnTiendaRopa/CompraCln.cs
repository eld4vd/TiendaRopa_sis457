using CadTiendaRopa;

namespace ClnTiendaRopa
{
    public class CompraCln
    {
        public static List<Compra> listar()
        {
            return new CompraCad().listar();
        }

        public static Compra obtenerPorId(int id)
        {
            return new CompraCad().obtenerPorId(id);
        }

        public static int crear(Compra compra)
        {
            if (compra.Detalles.Count == 0)
                throw new Exception("La compra debe tener al menos un producto");

            if (compra.Total <= 0)
                throw new Exception("El total de la compra debe ser mayor a 0");

            return new CompraCad().crear(compra);
        }

        public static int eliminar(int id)
        {
            return new CompraCad().eliminar(id);
        }
    }
}