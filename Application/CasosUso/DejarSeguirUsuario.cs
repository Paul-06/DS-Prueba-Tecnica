using Domain.Repositorios;

namespace Application.CasosUso
{
    public class DejarSeguirUsuario
    {
        // Atributos para inyeccion
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioSeguidoRepositorio _usuarioSeguidoRepositorio;

        // Constructor
        public DejarSeguirUsuario(IUsuarioRepositorio usuarioRepositorio, IUsuarioSeguidoRepositorio usuarioSeguidoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioSeguidoRepositorio = usuarioSeguidoRepositorio;
        }

        // Metodos
        public void Ejecutar(int seguidorId, int seguidoId)
        {
            var seguidor = _usuarioRepositorio.ObtenerUsuarioPorId(seguidorId);
            var seguido = _usuarioRepositorio.ObtenerUsuarioPorId(seguidoId);

            if (seguidor is null || seguido is null)
                throw new Exception("Usuario no encontrado");

            if (!_usuarioSeguidoRepositorio.EsSeguidor(seguidorId, seguidoId))
                throw new Exception("No lo estás siguiendo");

            _usuarioSeguidoRepositorio.EliminarSeguidor(seguidorId, seguidoId);
        }
    }
}
