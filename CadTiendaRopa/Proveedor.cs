using System.ComponentModel.DataAnnotations;

namespace CadTiendaRopa
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Contacto { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        public bool Eliminado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}