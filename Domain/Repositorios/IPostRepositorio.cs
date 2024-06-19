using Domain.Entidades;

namespace Domain.Repositorios
{
    public interface IPostRepositorio
    {
        void AgregarPost(Post post);
        IEnumerable<Post> ObtenerPostsPorUsuarioId(int idUsuario);
    }
}
