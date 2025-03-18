using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Repositories
{
    public class TipoDeEventoRepository : ITipoDeEventoRepository
    {

        private readonly Event_Context _context;

        public TipoDeEventoRepository (Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid Id, TipoDeEvento tipoDeEvento)
        {

            try
            {
                TipoDeEvento tipoBuscado = _context.TipoDeEventos.Find(Id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoEvento = tipoDeEvento.TituloTipoEvento;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoDeEvento BuscarPorId(Guid Id)
        {

            try
            {
                TipoDeEvento tipoDeEvento = _context.TipoDeEventos.Find(Id)!;
                return tipoDeEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoDeEvento novoTipoDeEvento)
        {
            try
            {
                _context.TipoDeEventos.Add(novoTipoDeEvento);
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
                TipoDeEvento eventoBuscado = _context.TipoDeEventos.Find(Id)!;
                if (eventoBuscado != null)
                { 
                
                    _context.Remove(eventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }





        public List<TipoDeEvento> Listar()
        {
            try
            {
                List<TipoDeEvento> listaTipoDeEventos = _context.TipoDeEventos
                     .Include(g => g.TituloTipoEvento)
                    .ToList();

                return listaTipoDeEventos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
