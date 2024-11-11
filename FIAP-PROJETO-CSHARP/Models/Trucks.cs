using System;
using System.ComponentModel.DataAnnotations;

namespace FIAP_PROJETO_CSHARP.Models
{
    public class Truck
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O código da placa é obrigatório!")]
        public string PlateCode { get; set; }

        [Required(ErrorMessage = "O nome do motorista é obrigatório!")]
        public string Driver { get; set; }

        [Required(ErrorMessage = "A data de registro é obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "A localização do caminhão é obrigatória!")]
        public string Location { get; set; }
    }
}
