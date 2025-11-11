using System.ComponentModel.DataAnnotations;

namespace CadTiendaRopa
{
    public class DetalleCompra
    {
        [Key]
        public int Id { get; set; }
        public int CompraId { get; set; }

        // FK a ProductosProveedor (en BD)
        public int ProductoProveedorId { get; set; }

        // Snapshots para UI (SIN duplicados, SIN inicializadores inválidos)
        public string ProductoNombre { get; set; } = "";
        public string ProductoTalla { get; set; } = "UNI";
        public string ProductoColor { get; set; } = "N/A";

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Propiedad calculada (debe ser getter, no campo)
        public decimal Subtotal => PrecioUnitario * Cantidad;
    }
}