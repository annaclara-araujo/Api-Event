using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {

        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController (IComentarioEventoRepository comentarioEventoRepository)
        {
            _comentarioEventoRepository = comentarioEventoRepository;
        } 


        [HttpPost]

        public ActionResult Post(ComentarioEvento comentario)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentario);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {

            try
            {
                _comentarioEventoRepository.Deletar(id);

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
                List<ComentarioEvento> listaComentarioEvento = _comentarioEventoRepository.Listar();
                return Ok(listaComentarioEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

      
        [HttpGet("BuscarPorIdUsuario/{UsuarioID},{EventoID}")]
        public IActionResult GetById(Guid UsuarioID, Guid EventoID)
        {
            try
            {
                ComentarioEvento novoComentarioEvento = _comentarioEventoRepository.BuscarPorIdUsuario(UsuarioID, EventoID);
                return Ok(novoComentarioEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}
