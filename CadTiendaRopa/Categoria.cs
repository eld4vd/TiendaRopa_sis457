using System.ComponentModel.DataAnnotations;

namespace CadTiendaRopa
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}