using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.AspNetCore.Identity;

namespace Api_Event.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly Event_Context _context;

        public UsuarioRepository (Event_Context context)
        {
            _context = context;
        }


        //Buscar Por Email e Senha
        public Usuario BuscarPorEmailSenha(string Email, string Senha)
        {
            throw new NotImplementedException();
        }



        //Buscar Por Id
        public Usuario BuscarPorId(Guid Id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.Find(Id)!;
                return usuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }



        //Cadastrar
        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
                _context.Usuario.Add(novoUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
