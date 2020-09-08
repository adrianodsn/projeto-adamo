using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("estados");

            HasMany(x => x.Cidades).WithRequired(x => x.Estado).HasForeignKey(x => x.EstadoId).WillCascadeOnDelete(false);
        }
    }
}