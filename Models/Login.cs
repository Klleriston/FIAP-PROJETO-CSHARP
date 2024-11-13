using System.ComponentModel.DataAnnotations;

namespace FIAP_PROJETO_CSHARP.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Por favor digite um Email !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor digite uma senha !")]
        public string Password { get; set; }
    }
}
