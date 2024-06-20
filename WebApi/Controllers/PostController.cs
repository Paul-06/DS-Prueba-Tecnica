using Application.CasosUso;
using Microsoft.AspNetCore.Mvc;
using WebApi.Requests;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        // Implementaremos nuestros casos de uso
        private readonly CrearPost _crearPost;
        private readonly ObtenerPostsSeguidos _obtenerPostsSeguidos;
        private readonly ObtenerPostsDeUsuario _obtenerPostsDeUsuario;

        // Constructor
        public PostController(CrearPost crearPost, ObtenerPostsSeguidos obtenerPostsSeguidos,  ObtenerPostsDeUsuario obtenerPostsDeUsuario)
        {
            _crearPost = crearPost;
            _obtenerPostsSeguidos = obtenerPostsSeguidos;
            _obtenerPostsDeUsuario = obtenerPostsDeUsuario;
        }

        // Metodos API
        [HttpPost]
        public IActionResult CrearPost([FromBody] CrearPostRequest request)
        {
            try
            {
                _crearPost.Ejecutar(request.IdUsuario, request.Contenido);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }    
        }

        [HttpGet("{username}/posts/seguidos")]
        public IActionResult ObtenerPostsDeSeguidosPorUsuario(string username)
        {
            try
            {
                var posts = _obtenerPostsSeguidos.Ejecutar(username);
                if (!posts.Any())
                    return NotFound($"No se encontraron posts para los seguidos del usuario: {username}");

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idUsuario}/posts")]
        public IActionResult ObtenerPostsDeUsuario(int idUsuario)
        {
            try
            {
                var posts = _obtenerPostsDeUsuario.Ejecutar(idUsuario);
                if (!posts.Any())
                    return NotFound("No se encontraron posts");

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
