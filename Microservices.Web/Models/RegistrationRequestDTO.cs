using System.ComponentModel.DataAnnotations;

namespace Microservices.Web.Models
{

    public class RegistrationRequestDTO
    {
        
        [Required(ErrorMessage ="O campo Email é Obrigatório")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Nome é Obrigatório")]
        [MinLength(10,ErrorMessage ="O campo deve ter no mínimo 10 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Telefone é Obrigatório")]
        //[Phone]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "O campo Senha é Obrigatório")]
        public string Password { get; set; }
        //[Required(ErrorMessage = "O campo Função é Obrigatório")]
        public string? Role { get; set; }
    }
}
