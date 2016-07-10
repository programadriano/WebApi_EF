using GerenciamentoDeUsuarios.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GerenciamentoDeUsuarios.Infra.EntityContiguration
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(60);


            HasRequired(x => x.Perfil);
        }
    }
}
