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
        private readonly CrearPost _crearPost;

        // Constructor
        public PostController(CrearPost crearPost)
        {
            _crearPost = crearPost;
        }

        // Metodos API
        [HttpPost]
        public IActionResult CrearPost([FromBody] CrearPostRequest request)
        {
            _crearPost.Ejecutar(request.IdUsuario, request.Contenido);
            return Ok();
        }
    }
}
