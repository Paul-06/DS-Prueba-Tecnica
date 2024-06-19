namespace Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
        public virtual ICollection<Post>? PostRelationList { get; set; }
        public virtual ICollection<UsuarioSeguido>? SeguidorRelationList { get; set; }
    }
}
