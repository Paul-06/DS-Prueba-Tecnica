namespace Domain.Entidades
{
    public class UsuarioSeguido
    {
        public int IdSeguidor { get; set; }
        public Usuario? Seguidor { get; set; }

        public int IdSeguido { get; set; }
        public Usuario? Seguido { get; set; }
    }
}
