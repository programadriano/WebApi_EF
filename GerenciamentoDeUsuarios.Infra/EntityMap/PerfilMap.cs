using GerenciamentoDeUsuarios.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GerenciamentoDeUsuarios.Infra.EntityContiguration
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("Pefil");

            HasKey(x => x.Id);

            Property(x => x.Nome)
                .HasMaxLength(70);
        }
    }
}
