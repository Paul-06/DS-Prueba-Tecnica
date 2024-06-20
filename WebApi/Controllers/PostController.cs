using Application.CasosUso;
using Microsoft.AspNetCore.Mvc;
using WebApi.Requests;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        // Implementaremos nuestro caso de uso "Crear Post"
        // y "ObtenerPostsSeguidos"
        private readonly CrearPost _crearPost;
        private readonly ObtenerPostsSeguidos _obtenerPostsSeguidos;

        // Constructor
        public PostController(CrearPost crearPost, ObtenerPostsSeguidos obtenerPostsSeguidos)
        {
            _crearPost = crearPost;
            _obtenerPostsSeguidos = obtenerPostsSeguidos;
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

        [HttpGet("{username}/posts")]
        public IActionResult ObtenerPostsPorUsuario(string username)
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
    }
}
