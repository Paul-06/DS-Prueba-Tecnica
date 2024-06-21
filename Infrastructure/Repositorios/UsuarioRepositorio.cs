using Domain.Entidades;
using Domain.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        // Atributo para manejar el dbContext
        private readonly AppDatabaseContext _context;

        // Constructor
        public UsuarioRepositorio(AppDatabaseContext context)
        {
            _context = context;
        }

        // Implementacion de la interfaz (contrato)
        public void ActualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> ObtenerDemasUsuarios(string username)
            => _context.Usuarios.Where(u => u.Username != username).ToList();

        public Usuario ObtenerUsuarioPorId(int id) 
            => _context.Usuarios.Find(id);

        public Usuario ObtenerUsuarioPorUsername(string username) 
            => _context.Usuarios.SingleOrDefault(u => u.Username == username);
    }
}
