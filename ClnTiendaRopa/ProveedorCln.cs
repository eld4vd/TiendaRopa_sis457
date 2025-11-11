using CadTiendaRopa;

namespace ClnTiendaRopa
{
    public class ProveedorCln
    {
        public static List<Proveedor> listar()
        {
            return new ProveedorCad().listar();
        }

        public static int crear(Proveedor proveedor)
        {
            return new ProveedorCad().crear(proveedor);
        }

        public static int actualizar(Proveedor proveedor)
        {
            return new ProveedorCad().actualizar(proveedor);
        }

        public static int eliminar(int id)
        {
            return new ProveedorCad().eliminar(id);
        }
    }
}