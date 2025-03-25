using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {

        private readonly Event_Context _context;

        public PresencaRepository (Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid Id, Presenca presencaEvento)
        {
            try
            {
                Presenca presencaEventoBuscado = _context.Presenca.Find(Id)!;

                if (presencaEventoBuscado != null)
                {
                    if (presencaEventoBuscado.Situacao)
                    {
                        presencaEventoBuscado.Situacao = false;
                    }
                    else
                    {
                        presencaEventoBuscado.Situacao = true;
                    }

                }

                _context.Presenca.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Presenca BuscarPorId(Guid Id)
        {

            try
            {
                return _context.Presenca
                    .Select(p => new Presenca
                    {
                        PresencaId = p.PresencaId,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            EventoId = p.EventoId!,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            DescricaoEvento = p.Evento.DescricaoEvento
                        }

                    }).FirstOrDefault(p => p.PresencaId == Id)!;
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
                Presenca presencaBuscado = _context.Presenca.Find(Id)!;

                if(presencaBuscado != null)
                {
                    _context.Presenca.Remove(presencaBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(Presenca inscricao)
        {
            try
            {
                inscricao.PresencaId = Guid.NewGuid();

                _context.Presenca.Add(inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Presenca> Listar()
        {
            try
            {
                return _context.Presenca
                    .Select(p => new Presenca
                    {
                        PresencaId = p.PresencaId,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            EventoId = p.EventoId,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            DescricaoEvento = p.Evento.DescricaoEvento
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Presenca> ListarMinhasPresencas(Guid Id)
        {
            return _context.Presenca
                .Select(p => new Presenca
                {
                    PresencaId = p.PresencaId,
                    Situacao = p.Situacao,
                    UsuarioId = p.UsuarioId,
                    EventoId = p.EventoId,

                    Evento = new Evento
                    {
                        EventoId = p.EventoId,
                        DataEvento = p.Evento!.DataEvento,
                        NomeEvento = p.Evento!.NomeEvento,
                      
                    }
                })
                .Where(p => p.UsuarioId == Id)
                .ToList();
        }
    }
}
