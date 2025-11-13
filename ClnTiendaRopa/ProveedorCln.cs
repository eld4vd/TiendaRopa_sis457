using CadTiendaRopa;
using System.Collections.Generic;
using System.Linq;

namespace ClnTiendaRopa
{
    public class ProveedorCln
    {
        public static List<Proveedor> listar()
        {
            return new ProveedorCad().listar();
        }

        // 🔥 MÉTODO BUSCAR - AGREGADO
        public static List<Proveedor> buscar(string criterio)
        {
            var lista = listar();
            return lista.Where(p =>
                p.Nombre.ToLower().Contains(criterio.ToLower()) ||
                (p.Contacto != null && p.Contacto.ToLower().Contains(criterio.ToLower())) ||
                (p.Telefono != null && p.Telefono.Contains(criterio))
            ).ToList();
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