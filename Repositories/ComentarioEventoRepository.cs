using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;

namespace Api_Event.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly Event_Context _context;

        public ComentarioEventoRepository(Event_Context context)
        {
            _context = context;
        }

        public ComentarioEvento BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoId = c.ComentarioEventoId,
                        Comentario = c.Comentario,
                        Exibe = c.Exibe,
                        UsuarioId = c.UsuarioId,
                        EventoId = c.EventoId,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.UsuarioId == UsuarioId && c.EventoId == EventoId)!;
            }
            catch (Exception)
            {
                throw;
            }
        }
        


        //Metodo Cadastrar
        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                comentarioEvento.ComentarioEventoId = Guid.NewGuid();
                _context.ComentarioEvento.Add(comentarioEvento);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid ComentarioId)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _context.ComentarioEvento.Find(Id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentarioEvento.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar(Guid id)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {

                        ComentarioEventoId = c.ComentarioEventoId,
                        Comentario = c.Comentario,
                        Exibe = c.Exibe,
                        UsuarioId = c.UsuarioId,
                        EventoId = c.EventoId,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.EventoId == id).ToList();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> ListarSomenteExibe(Guid Id)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        ComentarioEventoId = c.ComentarioEventoId,
                        Comentario = c.Comentario,
                        Exibe = c.Exibe,
                        UsuarioId = c.UsuarioId,
                        EventoId = c.EventoId,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.Exibe == true && c.EventoId == Id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}