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

                _context.Evento.Update(eventoBuscado!);
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
                return _context.Evento
                    .Select(e => new Evento
                    {
                        EventoId = e.EventoId,
                        NomeEvento = e.NomeEvento,
                        DescricaoEvento = e.DescricaoEvento,
                        DataEvento = e.DataEvento,
                        TipoDeEvento = new TipoDeEvento
                        {
                            TituloTipoEvento = e.TipoDeEvento!.TituloTipoEvento
                        }
                    }).FirstOrDefault(e => e.EventoId == Id)!;
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
                // Verifica se a data do evento é maior que a data atual
                if (novoEvento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                novoEvento.EventoId = Guid.NewGuid();

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
        

        public List<Evento> Listar()
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
                return _context.Evento
                    .Include(e => e.Presenca)
                    .Select(e => new Evento
                    {
                        EventoId = e.EventoId,
                        NomeEvento = e.NomeEvento,
                        DescricaoEvento = e.DescricaoEvento,
                        DataEvento = e.DataEvento,
                        TipoDeEventoId = e.TipoDeEventoId,
                        TipoDeEvento = new TipoDeEvento
                        {
                            TipoDeEventoId = e.TipoDeEventoId,
                            TituloTipoEvento = e.TipoDeEvento!.TituloTipoEvento
                        },
                        Presenca = new Presenca
                        {
                            UsuarioId = e.Presenca!.UsuarioId,
                            Situacao = e.Presenca!.Situacao
                        }
                    })
                    .Where(e => e.Presenca!.Situacao == true && e.Presenca.UsuarioId == Id)
                    .ToList();
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
                return _context.Evento
                    .Select(e => new Evento
                    {
                        EventoId = e.EventoId,
                        NomeEvento = e.NomeEvento,
                        DescricaoEvento = e.DescricaoEvento,
                        DataEvento = e.DataEvento,
                        TipoDeEventoId = e.TipoDeEventoId,
                        TipoDeEvento = new TipoDeEvento
                        {
                           TipoDeEventoId = e.TipoDeEventoId,
                            TituloTipoEvento = e.TipoDeEvento!.TituloTipoEvento
                        }

                    })
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}





