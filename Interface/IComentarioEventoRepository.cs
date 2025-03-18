using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IComentarioEventoRepository
    {
        //Adicionar comentario
        void Cadastrar(IComentarioEventoRepository comentarioEvento);

        //Deletar comentario
        void Deletar (Guid ComentarioId);

        //Listar comentario
        List<ComentarioEvento> Listar (Guid id);

        //Buscar comentario
        ComentarioEvento BuscarPorIdUsuario (Guid UsuarioId, Guid EventoId);



    }
}
