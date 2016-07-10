namespace GerenciamentoDeUsuarios.Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PerfilId { get; set; }
        
        public Perfil Perfil { get; set; }
    }
}
