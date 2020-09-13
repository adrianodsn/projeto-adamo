using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class PaiMap : EntityTypeConfiguration<Pai>
    {
        public PaiMap()
        {
            ToTable("pais");

            HasMany(x => x.Filhos).WithRequired(x => x.Pai).HasForeignKey(x => x.PaiId).WillCascadeOnDelete(false);
        }
    }
}