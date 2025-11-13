using CadTiendaRopa;
using System.Collections.Generic;

namespace ClnTiendaRopa
{
    public class ProductoCln
    {
        public static List<Producto> listar()
        {
            return new ProductoCad().listar();
        }

        public static Producto obtenerPorId(int id)
        {
            return new ProductoCad().obtenerPorId(id);
        }

        public static int crear(Producto producto)
        {
            return new ProductoCad().crear(producto);
        }

        public static int actualizar(Producto producto)
        {
            return new ProductoCad().actualizar(producto);
        }

        public static int eliminar(int id)
        {
            return new ProductoCad().eliminar(id);
        }

        public static List<Producto> buscar(string texto)
        {
            return new ProductoCad().buscar(texto);
        }

        // 🔥 MÉTODO PARA OBTENER CATEGORÍAS (para el ComboBox)
        public static List<Categoria> listarCategorias()
        {
            return new CategoriaCad().listar();
        }
    }
}