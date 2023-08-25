using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "Nome não pode ter mais que 50 caracteres")]
        public string? Nome { get; set; }
    }
}
