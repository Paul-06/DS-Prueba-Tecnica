using Application.Dtos;
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
        public IEnumerable<PostDto> Ejecutar(string username)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorUsername(username);

            if (usuario is null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var seguidosId = _usuarioSeguidoRepositorio.ObtenerSeguidosId(usuario.Id);

            var posts = new List<PostDto>();

            foreach (var id in seguidosId)
            {
                var postsDeSeguido = _postRepositorio.ObtenerPostsPorUsuarioId(id);
                foreach (var post in postsDeSeguido)
                {
                    posts.Add(new PostDto
                    {
                        Contenido = post.Contenido,
                        Username = post.Usuario.Username, // Agregar el username del seguido
                        FechaPublicacion = post.FechaPublicacion
                    });
                }
            }

            return posts.OrderByDescending(p => p.FechaPublicacion);
        }
    }
}
