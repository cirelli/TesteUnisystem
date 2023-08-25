using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public required string Nome { get; set; }
    }
}
