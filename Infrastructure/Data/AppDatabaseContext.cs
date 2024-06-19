using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDatabaseContext : DbContext
    {
        // Constructor
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {
        }

        // Entidades (tablas)
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UsuarioSeguido> UsuarioSeguidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aquí agregare configuraciones adicionales para
            // el tema de following
        }
    }
}
