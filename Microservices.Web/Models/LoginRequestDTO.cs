using System.ComponentModel.DataAnnotations;

namespace Microservices.Web.Models
{

    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "O campo UserName é Obrigatório")]
        [EmailAddress(ErrorMessage ="Formato de e-mail inválido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "O campo Senha é Obrigatório")]
        
        public string Password { get; set; }
    }
}
