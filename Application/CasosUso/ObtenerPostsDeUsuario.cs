using Application.Dtos;
using Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.CasosUso
{
    public class ObtenerPostsDeUsuario
    {
        // Atributos para inyeccion
        private readonly IPostRepositorio _postRepositorio;

        // Constructor
        public ObtenerPostsDeUsuario(IPostRepositorio postRepositorio)
        {
            _postRepositorio = postRepositorio;
        }

        // Metodos

        public IEnumerable<PostDto> Ejecutar(int idUsuario)
        {
            var posts = new List<PostDto>();

            var postsDeUsuario = _postRepositorio.ObtenerPostsPorUsuarioId(idUsuario);

            foreach (var post in postsDeUsuario)
            {
                posts.Add(new PostDto
                {
                    Contenido = post.Contenido,
                    FechaPublicacion = post.FechaPublicacion
                });
            }

            return posts.OrderByDescending(p => p.FechaPublicacion);
        }
    }
}