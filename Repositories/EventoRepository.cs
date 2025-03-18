using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;

namespace Api_Event.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Event_Context _context;

        public EventoRepository(Event_Context contexto)
        {
            _context = contexto;
        }


        public void Atualizar(Guid Id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(Id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.DescricaoEvento = evento.DescricaoEvento;
                    eventoBuscado.TipoDeEventoId = evento.TipoDeEventoId;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Evento BuscarPorId(Guid Id)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(Id)!;

                return eventoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                _context.Evento.Add(novoEvento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(Id)!;

                if (eventoBuscado != null)
                {
                    _context.Evento.Remove(eventoBuscado);
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                List<Evento> listaDeEventos = _context.Evento.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> ProximosEventos()
        {
            throw new NotImplementedException();
        }
    }
}
