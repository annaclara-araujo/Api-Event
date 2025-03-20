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


        //Atualizar
        public void Atualizar(Guid Id, TipoDeEvento tipoDeEvento)
        {

            try
            {
                TipoDeEvento tipoEventoBuscado = _context.TipoDeEventos.Find(Id)!;

                if (tipoEventoBuscado != null)
                {
                    tipoEventoBuscado.TituloTipoEvento = tipoDeEvento.TituloTipoEvento;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }


        //Buscar Por Id
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


        //Cadastrar
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


        //Deletar
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


        //Listar

        public List<TipoDeEvento> Listar()
        {
            try
            {
                List<TipoDeEvento> listaTipoDeEventos = _context.TipoDeEventos.ToList();
                return listaTipoDeEventos;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
