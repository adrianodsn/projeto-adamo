using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("cidades");

            Ignore(x => x.Excluir);
        }
    }
}