using CadTiendaRopa;

namespace ClnTiendaRopa
{
    public class CategoriaCln
    {
        public static List<Categoria> listar()
        {
            return new CategoriaCad().listar();
        }

        public static int crear(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new Exception("El nombre es obligatorio");

            return new CategoriaCad().crear(categoria);
        }

        public static int actualizar(Categoria categoria)
        {
            return new CategoriaCad().actualizar(categoria);
        }

        public static int eliminar(int id)
        {
            return new CategoriaCad().eliminar(id);
        }
    }
}