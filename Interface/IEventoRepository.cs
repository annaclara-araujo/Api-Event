using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IEventoRepository
    {
        void Cadastrar (Evento evento);
        List<Evento> ProximosEventos();
        List<Evento> ListarPorId(Guid Id);
        List<Evento> Listar(Guid Id);
        Evento BuscarPorId(Guid Id);
        void Atualizar (Guid Id, Evento evento);
        void Deletar(Guid Id);
    }
}

