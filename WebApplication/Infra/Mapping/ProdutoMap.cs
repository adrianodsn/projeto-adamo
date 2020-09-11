using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("produtos");

            HasMany(x => x.ItensCompra).WithRequired(x => x.Produto).HasForeignKey(x => x.ProdutoId).WillCascadeOnDelete(false);
        }
    }
}