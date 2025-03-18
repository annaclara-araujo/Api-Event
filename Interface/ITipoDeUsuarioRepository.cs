using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface ITipoDeUsuarioRepository
    {
        void Cadastrar(TipoDeUsuario tipoDeUsuario);
        void Atualizar(Guid Id, TipoDeUsuario tipoDeUsuario);
        void Deletar(Guid Id);

        List<TipoDeEvento> Listar();
        TipoDeUsuario BuscarPorId(Guid Id);




    }
}
