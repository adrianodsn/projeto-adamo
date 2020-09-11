using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            ToTable("fornecedores");

            HasMany(x => x.Compras).WithRequired(x => x.Fornecedor).HasForeignKey(x => x.FornecedorId).WillCascadeOnDelete(false);
        }
    }
}