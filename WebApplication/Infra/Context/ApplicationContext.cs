using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication.Entities;

namespace WebApplication.Infra.Context
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=NomeStringConexao")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<ItemVenda> ItensVenda { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<ItemCompra> ItensCompra { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Filho> Filhos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove a pluralização

            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations
                .AddFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}