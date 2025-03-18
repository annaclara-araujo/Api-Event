using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface ITipoDeEventoRepository
    {
        void Cadastrar(TipoDeEvento tipoDeEvento);
        void Atualizar(Guid Id, TipoDeEvento tipoDeEvento);
        void Deletar(Guid Id);

        List<TipoDeEvento> Listar();
        TipoDeEvento BuscarPorId(Guid Id);






    }
}
