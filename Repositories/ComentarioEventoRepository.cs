using Api_Event.Domains;
using Api_Event.Interface;

namespace Api_Event.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        public ComentarioEvento BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(IComentarioEventoRepository comentarioEvento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid ComentarioId)
        {
            throw new NotImplementedException();
        }

        public List<ComentarioEvento> Listar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
