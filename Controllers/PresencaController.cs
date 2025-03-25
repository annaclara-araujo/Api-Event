using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

        public class PresencaController : ControllerBase
        {
            private readonly IPresencaRepository _presencaRepository;

            public PresencaController(IPresencaRepository presencaRepository)
            {
                _presencaRepository = presencaRepository;
            }
            /// <summary>
            /// Endpoint para deletar a presença
            /// </summary>
            [HttpDelete("{id}")]
            public IActionResult Delete(Guid id)
            {
                try
                {
                    _presencaRepository.Deletar(id);
                    return NoContent();
                }
                catch (Exception error)
                {
                    return BadRequest(error.Message);
                }
            }

            /// <summary>
            /// Endpoint para buscar por Id a presença
            /// </summary>
            [HttpGet("BuscarPorId/{id}")]
            public IActionResult GetById(Guid id)
            {
                try
                {
                    Presenca novaPresenca = _presencaRepository.BuscarPorId(id);
                    return Ok(novaPresenca);
                }
                catch (Exception error)
                {
                    return BadRequest(error.Message);
                }
            }

            /// <summary>
            /// Endpoint para atualizar as presenças
            /// </summary>
            [HttpPut("{id}")]
            public IActionResult Put(Guid id, Presenca presenca)
            {
                try
                {
                    _presencaRepository.Atualizar(id, presenca);
                    return NoContent();
                }
                catch (Exception error)
                {
                    return BadRequest(error.Message);
                }
            }

            /// <summary>
            /// Endpoint para fazer uma lista das presenças
            /// </summary>
            [HttpGet("ListarPresencas")]
            public IActionResult Get()
            {
                try
                {
                    List<Presenca> listaPresencas = _presencaRepository.Listar();
                    return Ok(listaPresencas);
                }
                catch (Exception error)
                {
                    return BadRequest(error.Message);
                }
            }

            /// <summary>
            /// Endpoint para fazer uma lista das minhas presenças
            /// </summary>
            [HttpGet("PresencaEventos/{id}")]
            public IActionResult Get(Guid id)
            {
                try
                {
                    List<Presenca> listaMinhasPresencas = _presencaRepository.ListarMinhasPresencas(id);
                    return Ok(listaMinhasPresencas);
                }
                catch (Exception error)
                {
                    return BadRequest(error.Message);
                }
            }
        }
    }























































