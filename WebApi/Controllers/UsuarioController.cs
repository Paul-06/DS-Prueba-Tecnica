using Application.CasosUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Implementaremos nuestros casos de uso
        private readonly SeguirUsuario _seguirUsuario;
        private readonly ListarDemasUsuarios _listarDemasUsuarios;

        // Constructor
        public UsuarioController(SeguirUsuario seguirUsuario, ListarDemasUsuarios listarDemasUsuarios)
        {
            _seguirUsuario = seguirUsuario;
            _listarDemasUsuarios = listarDemasUsuarios;
        }

        // Metodos API
        [HttpGet("{username}/usuarios")]
        public IActionResult ObtenerDemasUsuario(string username)
        {
            try
            {
                var usuarios = _listarDemasUsuarios.Ejecutar(username);
                if (!usuarios.Any())
                    return NotFound("No se encontraron más usuarios");

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

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
