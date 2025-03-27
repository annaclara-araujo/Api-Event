using Api_Event.Domains;
using Api_Event.Interface;
using Api_Event.Repositories;
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

        /// <summary>
        /// Endpoint para cadastrar novo evento
        /// </summary>
        /// <param name="novoEvento"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Endpoint para deletar Evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Endpoint para atualizar evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="novoEvento"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Endpoint para buscar evento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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


        /// <summary>
        /// Endpoint para listar Evento
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }


        /// <summary>
        /// Endpoint para Listar evento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("ListarPorId/{id}")]

        public IActionResult GetByEvento(Guid id)
        {
            try
            {
                List<Evento> listaEventoId = _eventoRepository.Listar();
                return Ok(listaEventoId);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para Listar proximos eventos
        /// </summary>
        /// <returns></returns>

        [HttpGet("ProximosEventos")]
        public IActionResult GetByProximo()
        {
            try
            {
                List<Evento> proximosEventos = _eventoRepository.Listar();
                return Ok(proximosEventos);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}























