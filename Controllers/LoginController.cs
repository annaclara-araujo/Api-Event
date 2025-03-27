using Api_Event.Domains;
using Api_Event.DTOS;
using Api_Event.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para Login
        /// </summary>
        /// <param name="LoginDTO"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Login(LoginDTO LoginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(LoginDTO.Email, LoginDTO.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario nao encontrado, email ou senha invalidos!");
                }

                // 1 passo- 
                var claims = new[]
                {

                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.UsuarioId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.EmailUsuario!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.SenhaUsuario!),
                    new Claim("Tipo do usuario", usuarioBuscado.TipoDeUsuario!.TituloTipoUsuario!),

                    new Claim("Nome da Claim","Valor da Claim")
                };

                // definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventos-chave-autentificacao-webapi-dev"));


                // Definir as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gerar o Token
                var token = new JwtSecurityToken
                (
                    //emissor 
                    issuer: "Api-Event",

                    //destinatario
                    audience: "Api-Event",

                    //dados definidos nas claims
                    claims: claims,

                    //tempo de expiracao do teken
                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: creds

                );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
