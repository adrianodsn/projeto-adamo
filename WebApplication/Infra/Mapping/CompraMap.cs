using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class CompraMap : EntityTypeConfiguration<Compra>
    {
        public CompraMap()
        {
            ToTable("compras");

            HasMany(x => x.ItensCompra).WithRequired(x => x.Compra).HasForeignKey(x => x.CompraId).WillCascadeOnDelete(true);
        }
    }
}