using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace Api_Event.DTOS
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Informe o email do usuario!")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Informe a senha do usuario!")]

        public string? Senha { get; set; }






    }
}
