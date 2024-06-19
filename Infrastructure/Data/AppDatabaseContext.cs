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

            // Configuraciones para las entidades en la base de datos
            // Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Post
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Contenido)
                .IsRequired()
                .HasMaxLength(280); // Limite actual de caracteres por Tweet

                entity.Property(e => e.FechaPublicacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Relacion
                entity.HasOne(e => e.Usuario)
                .WithMany(u => u.PostRelationList)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
            });

            // UsuarioSeguido (N:N)
            modelBuilder.Entity<UsuarioSeguido>(entity =>
            {
                entity.HasKey(us => new { us.IdSeguidor, us.IdSeguido });

                entity.HasOne(us => us.Seguidor)
                    .WithMany(u => u.Seguidos)
                    .HasForeignKey(us => us.IdSeguidor)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(us => us.Seguido)
                    .WithMany(u => u.Seguidores)
                    .HasForeignKey(us => us.IdSeguido)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
