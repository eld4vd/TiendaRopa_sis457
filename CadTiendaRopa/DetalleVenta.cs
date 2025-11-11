using System.ComponentModel.DataAnnotations;

namespace CadTiendaRopa
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        public int VentaId { get; set; }
        public int ProductoId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        // Propiedades calculadas
        public decimal Subtotal => Cantidad * PrecioUnitario;

        // Propiedades de navegación
        public string ProductoNombre { get; set; }
        public string ProductoTalla { get; set; }
        public string ProductoColor { get; set; }
    }
}