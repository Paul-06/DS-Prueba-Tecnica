using Domain.Entidades;

namespace Domain.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario ObtenerUsuarioPorId(int id);
        Usuario ObtenerUsuarioPorUsername(string username);
        void AgregarUsuario(Usuario usuario);
        void ActualizarUsuario(Usuario usuario);
    }
}
