using Application.CasosUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Implementaremos nuestro caso de uso "SeguirUsuario"
        private readonly SeguirUsuario _seguirUsuario;

        // Constructor
        public UsuarioController(SeguirUsuario seguirUsuario)
        {
            _seguirUsuario = seguirUsuario;
        }

        // Metodos API
        [HttpPost("{seguidorId}/seguir/{seguidoId}")]
        public IActionResult SeguirUsuario(int seguidorId, int seguidoId)
        {
            try
            {
                _seguirUsuario.Ejecutar(seguidorId, seguidoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
