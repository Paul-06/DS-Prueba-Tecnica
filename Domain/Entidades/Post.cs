namespace Domain.Entidades
{
    public class Post
    {
        public int Id { get; set; }
        public string? Contenido { get; set; }
        public DateTimeOffset FechaPublicacion { get; set; }
        public int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
