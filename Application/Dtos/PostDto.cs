namespace Application.Dtos
{
    public class PostDto
    {
        public string? Contenido { get; set; }
        public string? Username { get; set; }
        public DateTimeOffset FechaPublicacion { get; set; }
    }
}