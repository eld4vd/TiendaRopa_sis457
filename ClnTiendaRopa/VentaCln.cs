using CadTiendaRopa;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClnTiendaRopa
{
    public class VentaCln
    {
        public static List<Venta> listar()
        {
            return new VentaCad().listar();
        }

        // 🔥 MÉTODO BUSCAR - AGREGADO
        public static List<Venta> buscar(string criterio)
        {
            var lista = listar();
            return lista.Where(v =>
                v.ClienteNombre.ToLower().Contains(criterio.ToLower()) ||
                v.EmpleadoNombre.ToLower().Contains(criterio.ToLower()) ||
                v.Id.ToString().Contains(criterio)
            ).ToList();
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