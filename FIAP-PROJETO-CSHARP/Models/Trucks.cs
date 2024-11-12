using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP_PROJETO_CSHARP.Models
{
    [Table("TRUCKS")]
    public class Truck
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O código da placa é obrigatório!")]
        [Column("PLATE_CODE")]
        public string PlateCode { get; set; }

        [Required(ErrorMessage = "O nome do motorista é obrigatório!")]
        [Column("DRIVER")]
        public string Driver { get; set; }

        [Required(ErrorMessage = "A data de registro é obrigatória!")]
        [Column("REGISTRATION_DATE")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "A localização do caminhão é obrigatória!")]
        [Column("LOCATION")]
        public string Location { get; set; }
    }
}
