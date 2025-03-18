using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.AspNetCore.Identity;

namespace Api_Event.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario BuscarPorEmailSenha(string Email, string Senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
