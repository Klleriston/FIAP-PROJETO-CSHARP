using System.ComponentModel.DataAnnotations;

namespace FIAP_PROJETO_CSHARP.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Nome de usuario é obrigatorio !")]
        public string Userame { get; set; }
        [Required(ErrorMessage = "Email é obrigatorio !")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatoria !")]
        public string Password { get; set; }

        public List<string> Roles { get; set; } = new List<string>();
    }
}
