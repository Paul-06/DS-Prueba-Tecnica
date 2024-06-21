using Application.CasosUso;
using Domain.Repositorios;
using Infrastructure.Data;
using Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Agregamos el DbContext
builder.Services.AddDbContext<AppDatabaseContext>(opt =>
{
    // En esta ocasion, permitire que los datos sensibles
    // se incluyan en los logs (no debe realizarse estando en produccion)
    opt.LogTo(Console.WriteLine, new[] {
        DbLoggerCategory.Database.Command.Name},
        LogLevel.Information).EnableSensitiveDataLogging();

    opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteDatabase"));
});

// Configuramos nuestros casos de uso
builder.Services.AddScoped<CrearPost>();
builder.Services.AddScoped<DejarSeguirUsuario>();
builder.Services.AddScoped<SeguirUsuario>();
builder.Services.AddScoped<ObtenerPostsSeguidos>();
builder.Services.AddScoped<ObtenerPostsDeUsuario>();
builder.Services.AddScoped<ListarDemasUsuarios>();

// Configuramos nuestros repositorios
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IPostRepositorio, PostRepositorio>();
builder.Services.AddScoped<IUsuarioSeguidoRepositorio, UsuarioSeguidoRepositorio>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregamos el servicio CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigenesExternos",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Usamos la politica CORS configurada
app.UseCors("PermitirOrigenesExternos");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var ambiente = app.Services.CreateScope())
{
    var services = ambiente.ServiceProvider;

    try
    {
        // Instanciamos context (parametro de LoadDatabase)
        var context = services.GetRequiredService<AppDatabaseContext>();

        // Creamos la BD
        await context.Database.MigrateAsync(); // MigrateAsync() se encarga de aplicar las migraciones pendientes

        // Hacemos la insercion de la data de prueba
        await LoadDatabase.InsertarData(context);
    }
    catch (Exception ex)
    {
        var logging = services.GetRequiredService<ILogger<Program>>();
        logging.LogError(ex, "Ocurrió un error en la inserción de datos.");
    }
}

app.Run();
