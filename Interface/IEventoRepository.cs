using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IEventoRepository
    {
        void Cadastrar (Evento evento);
        List<Evento> ProximosEventos();
        List<Evento> ListarPorId(int id);
        List<Evento> Listar();
        Evento BuscarPorId(Guid Id);
        void Atualizar (Guid Id, Evento evento);
        void Deletar(Guid Id);
    }
}

