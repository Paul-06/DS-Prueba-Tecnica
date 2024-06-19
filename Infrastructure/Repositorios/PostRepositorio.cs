using Domain.Entidades;
using Domain.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class PostRepositorio : IPostRepositorio
    {
        // Atributo para manejar el dbContext
        private readonly AppDatabaseContext _context;

        // Constructor
        public PostRepositorio(AppDatabaseContext context)
        {
            _context = context;
        }

        // Implementacion de la interfaz (contrato)
        public void AgregarPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public IEnumerable<Post> ObtenerPostsPorUsuarioId(int idUsuario)
        {
            return _context.Posts.Where(p => p.IdUsuario == idUsuario).ToList();
        }
    }
}
