using Domain.Entidades;
using Domain.Repositorios;

namespace Application.CasosUso
{
    public class ObtenerPostsSeguidos
    {
        // Atributos para inyeccion
        private readonly IUsuarioSeguidoRepositorio _usuarioSeguidoRepositorio;
        private readonly IPostRepositorio _postRepositorio;

        // Constructor
        public ObtenerPostsSeguidos(IUsuarioSeguidoRepositorio usuarioSeguidoRepositorio, IPostRepositorio postRepositorio)
        {
            _usuarioSeguidoRepositorio = usuarioSeguidoRepositorio;
            _postRepositorio = postRepositorio;
        }

        // Metodos
        public IEnumerable<Post> Ejecutar(int usuarioId)
        {
            var seguidores = _usuarioSeguidoRepositorio.ObtenerSeguidores(usuarioId);

            var posts = new List<Post>();

            foreach (var seguidor in seguidores)
            {
                posts.AddRange(_postRepositorio.ObtenerPostsPorUsuarioId(seguidor.Id));
            }

            return posts.OrderByDescending(p => p.FechaPublicacion);
        }
    }
}
