using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IComentarioEventoRepository
    {
        //Adicionar comentario
        void Cadastrar(ComentarioEvento comentarioEvento);

        //Deletar comentario
        void Deletar (Guid Id);

        //Listar comentario
        List<ComentarioEvento> Listar (Guid Id);

        //Buscar comentario
        ComentarioEvento BuscarPorIdUsuario (Guid UsuarioId, Guid EventoId);



    }
}
