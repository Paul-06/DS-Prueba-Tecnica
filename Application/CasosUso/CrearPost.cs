using Domain.Entidades;
using Domain.Repositorios;

namespace Application.CasosUso
{
    public class CrearPost
    {
        //Atributos para inyeccion
        private readonly IPostRepositorio _postRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        // Constructor
        public CrearPost(IPostRepositorio postRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _postRepositorio = postRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        // Metodos
        public void Ejecutar(int usuarioId, string contenido)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorId(usuarioId);
            if (usuario == null) throw new Exception("Usuario no encontrado");

            var post = new Post
            {
                Contenido = contenido,
                FechaPublicacion = DateTimeOffset.Now,
                IdUsuario = usuarioId
            };

            _postRepositorio.AgregarPost(post);
        }
    }
}
