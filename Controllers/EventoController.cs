using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }



        [HttpPost]

        public IActionResult Post(Evento novoEvento)
        {
            try
            {
                _eventoRepository.Cadastrar(novoEvento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Atualizar
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Evento novoEvento)
        {
            try
            {
                _eventoRepository.Atualizar(id, novoEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //Buscar Por Id

        [HttpGet("BuscarPorId/{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                Evento eventoBuscarPorId = _eventoRepository.BuscarPorId(id);
                return Ok(eventoBuscarPorId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        //Listar

        [HttpGet]

        public IActionResult Get()
        {

            try
            {
                List<Evento> listaDeEvento = _eventoRepository.Listar();
                return Ok(listaDeEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }


    }

}






















    
