using System.ComponentModel.DataAnnotations;

namespace CadTiendaRopa
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public decimal Total { get; set; }

        public int ProveedorId { get; set; }
        public int EmpleadoId { get; set; }

        public bool Eliminado { get; set; }

        // Propiedades de navegación
        public string ProveedorNombre { get; set; }
        public string EmpleadoNombre { get; set; }

        public List<DetalleCompra> Detalles { get; set; }

        public Compra()
        {
            Fecha = DateTime.Now;
            Detalles = new List<DetalleCompra>();
        }
    }
}