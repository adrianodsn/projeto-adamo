using System.Data.Entity.ModelConfiguration;
using WebApplication.Entities;

namespace WebApplication.Infra.Mapping
{
    class FilhoMap : EntityTypeConfiguration<Filho>
    {
        public FilhoMap()
        {
            ToTable("filhos");

            Ignore(x => x.Excluir);
        }
    }
}