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


        [HttpPut("{id}")]

        public IActionResult Put(Guid id, TipoDeUsuario tipoDeUsuario)
        {
            try
            {
                _tipoDeUsuarioRepository.Atualizar(id, tipoDeUsuario);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("BuscarPorId/{id}")]

        public IActionResult GetById(Guid id)
        {

            try
            {
                TipoDeUsuario tipoUsuarioBuscado = _tipoDeUsuarioRepository.BuscarPorId(id);
                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

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

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {

            try
            {
                _tipoDeUsuarioRepository.Deletar(id);
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

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

    }
    }
