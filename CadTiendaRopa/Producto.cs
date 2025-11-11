using System.ComponentModel.DataAnnotations;

namespace CadTiendaRopa
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "La talla es obligatoria")]
        [StringLength(3)]
        public string Talla { get; set; } = "";

        [Required(ErrorMessage = "El color es obligatorio")]
        [StringLength(30)]
        public string Color { get; set; } = "";

        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        public int Stock { get; set; }

        // BD: CategoriaId (FK a Categorias)
        public int? CategoriaId { get; set; }

        // UI: nombre de categoría (resultado del join en ProductoCad)
        public string Categoria { get; set; } = "";

        public bool EsDeProveedor { get; set; }
        public bool Eliminado { get; set; }

        // 🔥 NUEVO: URL de la imagen
        [StringLength(500)]
        public string? ImagenUrl { get; set; }

        public override string ToString() => Nombre;
    }
}