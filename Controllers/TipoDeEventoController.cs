using Api_Event.Domains;
using Api_Event.Interface;
using Api_Event.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoDeEventoController : ControllerBase
    {

        private readonly ITipoDeEventoRepository _tipoDeEventoRepository;

        public TipoDeEventoController(ITipoDeEventoRepository tipoDeEventoRepository)
        {
            _tipoDeEventoRepository = tipoDeEventoRepository;
        }

        // Metodo de Cadastrar
        [HttpPost]
        public IActionResult Post(TipoDeEvento novoTipoDeEvento)
        {
            try
            {
                _tipoDeEventoRepository.Cadastrar(novoTipoDeEvento);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Metodo Atualizar
       
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, TipoDeEvento tipoDeEvento)
        {
            try
            {
                _tipoDeEventoRepository.Atualizar(id, tipoDeEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        //Metodo Deletar

       
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _tipoDeEventoRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoDeEvento tipoDeEventoBuscado = _tipoDeEventoRepository.BuscarPorId(id);
                return Ok(tipoDeEventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoDeEventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }










    }
}
