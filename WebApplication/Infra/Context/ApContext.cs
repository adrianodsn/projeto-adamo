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
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<ItemVenda> ItensVenda { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<ItemCompra> ItensCompra { get; set; }

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