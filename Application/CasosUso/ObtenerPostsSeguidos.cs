using Domain.Entidades;
using Domain.Repositorios;

namespace Application.CasosUso
{
    public class ObtenerPostsSeguidos
    {
        // Atributos para inyeccion
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioSeguidoRepositorio _usuarioSeguidoRepositorio;
        private readonly IPostRepositorio _postRepositorio;

        // Constructor
        public ObtenerPostsSeguidos(IUsuarioRepositorio usuarioRepositorio, IUsuarioSeguidoRepositorio usuarioSeguidoRepositorio, IPostRepositorio postRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioSeguidoRepositorio = usuarioSeguidoRepositorio;
            _postRepositorio = postRepositorio;
        }

        // Metodos
        public IEnumerable<Post> Ejecutar(string username)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorUsername(username);

            if (usuario is null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var seguidores = _usuarioSeguidoRepositorio.ObtenerSeguidores(usuario.Id);

            var posts = new List<Post>();

            foreach (var seguidor in seguidores)
            {
                posts.AddRange(_postRepositorio.ObtenerPostsPorUsuarioId(seguidor.Id));
            }

            return posts.OrderByDescending(p => p.FechaPublicacion);
        }
    }
}
