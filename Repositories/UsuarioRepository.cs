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
            try
            {
                Usuario usuarioBuscado = _context.Usuario
                .Select(u => new Usuario
                {
                    UsuarioId = u.UsuarioId,
                    NomeUsuario = u.NomeUsuario,
                    EmailUsuario = u.EmailUsuario,
                    SenhaUsuario = u.SenhaUsuario,

                    TipoDeUsuario = new TipoDeUsuario
                    {
                        TipoDeUsuarioId = u.TipoDeUsuarioId,
                        TituloTipoUsuario = u.TipoDeUsuario!.TituloTipoUsuario

                    }
                }).FirstOrDefault(u => u.EmailUsuario == Email)!;
            
            }
            catch (Exception)
            {

                throw;
            }
        }



        //Buscar Por Id
        public Usuario BuscarPorId(Guid Id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario
                    .Select(u => new Usuario
                    {
                        UsuarioId = u.UsuarioId,
                        NomeUsuario= u.NomeUsuario,
                        EmailUsuario= u.EmailUsuario,
                        SenhaUsuario = u.SenhaUsuario,

                        TipoDeUsuario =new TipoDeUsuario 
                        {
                            TipoDeUsuarioId = u.TipoDeUsuario!.TipoDeUsuarioId,
                            TituloTipoUsuario = u.TipoDeUsuario!.TituloTipoUsuario
                        }

                    }).FirstOrDefault(u => u.UsuarioId == Id)!;

                    if(usuarioBuscado == null)
                {
                    return usuarioBuscado;
                }
                return null!;
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
