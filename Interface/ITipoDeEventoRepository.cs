using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface ITipoDeEventoRepository
    {
        void Cadastrar(TipoDeEvento tipoEvento);
        void Deletar(Guid id);
        List<TipoDeEvento> Listar();
        TipoDeEvento BuscarPorId(Guid id);
        void Atualizar(Guid id, TipoDeEvento tipoEvento);
    }
}
