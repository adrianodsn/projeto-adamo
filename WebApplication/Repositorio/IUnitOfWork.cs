
namespace WebApplication.Repositorio
{
    public interface IUnitOfWork
    {
        IEstadoRepository EstadoRepository { get; }
        ICidadeRepository CidadeRepository { get; }
        IPessoaRepository PessoaRepository { get; }
        IFornecedorRepository FornecedorRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        ICompraRepository CompraRepository { get; }
        void Commit();
    }
}