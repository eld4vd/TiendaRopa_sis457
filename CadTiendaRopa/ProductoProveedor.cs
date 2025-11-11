using System.ComponentModel.DataAnnotations;

namespace CadTiendaRopa
{
    public class ProductoProveedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal PrecioProveedor { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        public int? CategoriaId { get; set; }

        public bool Eliminado { get; set; }

        // Propiedades de navegación
        public string ProveedorNombre { get; set; }
        public string CategoriaNombre { get; set; }

        public override string ToString()
        {
            return $"{Nombre} - Bs. {PrecioProveedor:N2}";
        }
    }
}