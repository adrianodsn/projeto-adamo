using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class ItemCompraMap : EntityTypeConfiguration<ItemCompra>
    {
        public ItemCompraMap()
        {
            ToTable("itens_compra");

            Ignore(x => x.Excluir);
        }
    }
}