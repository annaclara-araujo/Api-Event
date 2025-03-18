using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IUsuarioRepository
    {
        void Cadastrar (Usuario novoUsuario);

        Usuario BuscarPorId (Guid Id);
        Usuario BuscarPorEmailSenha (string Email, string Senha);

    }
}
