using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class ItemVendaMap : EntityTypeConfiguration<ItemVenda>
    {
        public ItemVendaMap()
        {
            ToTable("itens_venda");

            Ignore(x => x.Excluir);
        }
    }
}