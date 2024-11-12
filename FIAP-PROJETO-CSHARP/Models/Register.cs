using System.ComponentModel.DataAnnotations;

namespace FIAP_PROJETO_CSHARP.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Por favor digite um nome de usuario !")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Por favor digite um email !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor digite uma senha !")]
        public string Password { get; set; }
    }
}
