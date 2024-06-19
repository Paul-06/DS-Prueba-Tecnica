using Domain.Entidades;

namespace Infrastructure.Data
{
    public class LoadDatabase
    {
        public static async Task InsertarData(AppDatabaseContext context)
        {
            if(!context.Usuarios.Any()) // Si hay usuarios, los agregamos
            {
                await context.Usuarios.AddRangeAsync(
                    new Usuario { Username = "Alfonso" }, 
                    new Usuario { Username = "Ivan" }, 
                    new Usuario { Username = "Alicia" }
                );

                // Disparamos los cambios a la bd
                await context.SaveChangesAsync();
            }
        }
    }
}
