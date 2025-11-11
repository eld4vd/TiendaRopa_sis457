using CadTiendaRopa;

namespace ClnTiendaRopa
{
    public class ClienteCln
    {
        public static List<Cliente> listar()
        {
            return new ClienteCad().listar();
        }

        public static int crear(Cliente cliente)
        {
            return new ClienteCad().crear(cliente);
        }

        public static int actualizar(Cliente cliente)
        {
            return new ClienteCad().actualizar(cliente);
        }

        public static int eliminar(int id)
        {
            return new ClienteCad().eliminar(id);
        }

        public static List<Cliente> buscar(string texto)
        {
            return new ClienteCad().buscar(texto);
        }
    }
}