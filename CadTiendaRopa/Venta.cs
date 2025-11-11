using System.ComponentModel.DataAnnotations;

namespace CadTiendaRopa
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public decimal Total { get; set; }

        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }

        public bool Eliminado { get; set; }

        // Propiedades de navegación
        public string EmpleadoNombre { get; set; }
        public string ClienteNombre { get; set; }

        public List<DetalleVenta> Detalles { get; set; }

        public Venta()
        {
            Fecha = DateTime.Now;
            Detalles = new List<DetalleVenta>();
        }
    }
}