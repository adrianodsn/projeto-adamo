using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication.Entities;

namespace WebApplication.Infra.Context
{
    public partial class ApContext : DbContext
    {
        public ApContext() : base("name=ApContext") { }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove a pluralização

            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations
                .AddFromAssembly(typeof(ApContext).Assembly);
        }
    }
}