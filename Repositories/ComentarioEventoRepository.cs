using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;

namespace Api_Event.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly Event_Context _context;

        public ComentarioEventoRepository (Event_Context context)
        {
            _context = context;
        }

        public ComentarioEvento BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId)
        {
            throw new NotImplementedException();
        }


        //Metodo Cadastrar
        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
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
                List<ComentarioEvento> comentarioEvento = _context.ComentarioEvento.ToList();
                return comentarioEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
