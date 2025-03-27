using Api_Event.Domains;
using Api_Event.Interface;
using Api_Event.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoDeUsuarioController : ControllerBase
    {

        private readonly ITipoDeUsuarioRepository _tipoDeUsuarioRepository;

        public TipoDeUsuarioController(ITipoDeUsuarioRepository tipoDeUsuarioRepository)
        {
            _tipoDeUsuarioRepository = tipoDeUsuarioRepository;
        }


        /// <summary>
        /// Endpoint para atualizar o tipo de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoDeUsuario"></param>
        /// <returns></returns>
        [HttpGet("BuscarPorId/{Id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                TipoDeUsuario usuarioBuscado = _tipoDeUsuarioRepository.BuscarPorId(Id);

                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// Endpoint para Cadastrar tipo de usuario
        /// </summary>
        /// <param name="novotipoDeUsuario"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Post(TipoDeUsuario novotipoDeUsuario)
        {
            try
            {
                _tipoDeUsuarioRepository.Cadastrar(novotipoDeUsuario);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }       
        }

        /// <summary>
        /// Endpoint para deletar tipo de usuario
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _tipoDeUsuarioRepository.Deletar(Id);
                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        /// <summary>
        /// Endpoint para listar tipo de usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {  
                return Ok(_tipoDeUsuarioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Put(Guid Id, TipoDeUsuario tipoDeUsuario)
        {
            try
            {
                _tipoDeUsuarioRepository.Atualizar(Id, tipoDeUsuario);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }


    }
}
