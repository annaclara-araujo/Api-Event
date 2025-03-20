using System.Timers;
using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Event_Context _context;

        public EventoRepository(Event_Context contexto)
        {
            _context = contexto;
        }


        //Atualizar
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

        //Buscar Por ID
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

        //Cadastrar
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


        //Deletar
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


        //Lista De Eventos
        public List<Evento> Listar(Guid Id)
        {
            try
            {
                List<Evento> listaDeEventos = _context.Evento.ToList();
                return listaDeEventos;

            }
            catch (Exception)
            {

                throw;
            }
        }

 
            //Lista Por ID  
        public List<Evento> ListarPorId(Guid EventoId)
        {
            try
            {
                List<Evento> listaEventoPorId = _context.Evento

                    .Include(g => g.EventoId).Where(f => f.EventoId == EventoId)
                    .ToList();

                return listaEventoPorId;
            } 
            catch (Exception)
            {

                throw;
            }
        }

        //Lista proximos eventos
        public List<Evento> ProximosEventos()
        {
            try
            {
                List<Evento> listaProximosEventos = _context.Evento.ToList();
                return listaProximosEventos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}





