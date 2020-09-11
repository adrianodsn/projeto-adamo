using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class VendaMap : EntityTypeConfiguration<Venda>
    {
        public VendaMap()
        {
            ToTable("vendas");

            HasMany(x => x.ItensVenda).WithRequired(x => x.Venda).HasForeignKey(x => x.VendaId).WillCascadeOnDelete(false);
        }
    }
}