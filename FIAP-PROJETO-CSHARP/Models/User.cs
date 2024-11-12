using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP_PROJETO_CSHARP.Models
{
    [Table("USERS")] 
    public class User
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome de usuario é obrigatorio!")]
        [Column("USERNAME")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email é obrigatorio!")]
        [EmailAddress]
        [Column("EMAIL")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatoria!")]
        [Column("PASSWORD")]
        public string Password { get; set; }
    }
}
