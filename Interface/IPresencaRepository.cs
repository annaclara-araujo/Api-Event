using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IPresencaRepository
    {
        void Deletar(Guid Id);
        void Inscrever (Presenca inscricao);
        void Atualizar (Guid Id, Presenca presenca);
        List<Presenca> Listar();
        Presenca BuscarPorId(Guid Id);
        List<Presenca> ListarPresencas(Guid Id);
    }
}
