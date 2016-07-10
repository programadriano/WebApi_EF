using GerenciamentoDeUsuarios.Domain.Entidades;
using System.Data.Entity;

namespace GerenciamentoDeUsuarios.Infra.Contextos
{
    public class GerenciamentoDeUsuariosContext : DbContext
    {
        //3.5
        public GerenciamentoDeUsuariosContext()
            : base("GerenciamentoDeUsuarios")
        {

        }

        //3.6 dbSet
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityContiguration.PerfilMap());
            modelBuilder.Configurations.Add(new EntityContiguration.UsuarioMap());
        }
    }
}
