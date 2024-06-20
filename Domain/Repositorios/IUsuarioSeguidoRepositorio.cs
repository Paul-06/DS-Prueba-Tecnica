using Domain.Entidades;

namespace Domain.Repositorios
{
    public interface IUsuarioSeguidoRepositorio
    {
        void AgregarSeguidor(int idSeguidor, int idSeguido);
        void EliminarSeguidor(int idSeguidor, int idSeguido);
        bool EsSeguidor(int idSeguidor, int idSeguido);
        IEnumerable<int> ObtenerSeguidosId(int idSeguidor);
    }
}
