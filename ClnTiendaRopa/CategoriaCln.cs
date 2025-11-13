using CadTiendaRopa;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClnTiendaRopa
{
    public class CategoriaCln
    {
        public static List<Categoria> listar()
        {
            return new CategoriaCad().listar();
        }

        // 🔥 MÉTODO BUSCAR - AGREGADO
        public static List<Categoria> buscar(string criterio)
        {
            var lista = listar();
            return lista.Where(c =>
                c.Nombre.ToLower().Contains(criterio.ToLower()) ||
                (c.Descripcion != null && c.Descripcion.ToLower().Contains(criterio.ToLower()))
            ).ToList();
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