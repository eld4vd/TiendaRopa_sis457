using System.ComponentModel.DataAnnotations;

namespace CadTiendaRopa
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [StringLength(20)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50)]
        public string Contraseña { get; set; }

        public bool Eliminado { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({Usuario})";
        }
    }
}