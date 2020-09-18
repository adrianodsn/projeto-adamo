using System;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext Context = null;

        private EstadoRepository _EstadoRepository = null;
        private CidadeRepository _CidadeRepository = null;
        private PessoaRepository _PessoaRepository = null;
        private FornecedorRepository _FornecedorRepository = null;
        private ProdutoRepository _ProdutoRepository = null;
        private CompraRepository _CompraRepository = null;

        public UnitOfWork()
        {
            Context = new ApplicationContext();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public IEstadoRepository EstadoRepository
        {
            get
            {
                if (_EstadoRepository == null)
                {
                    _EstadoRepository = new EstadoRepository(Context);
                }

                return _EstadoRepository;
            }
        }

        public ICidadeRepository CidadeRepository
        {
            get
            {
                if (_CidadeRepository == null)
                {
                    _CidadeRepository = new CidadeRepository(Context);
                }

                return _CidadeRepository;
            }
        }

        public IPessoaRepository PessoaRepository
        {
            get
            {
                if (_PessoaRepository == null)
                {
                    _PessoaRepository = new PessoaRepository(Context);
                }

                return _PessoaRepository;
            }
        }

        public IFornecedorRepository FornecedorRepository
        {
            get
            {
                if (_FornecedorRepository == null)
                {
                    _FornecedorRepository = new FornecedorRepository(Context);
                }

                return _FornecedorRepository;
            }
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                if (_ProdutoRepository == null)
                {
                    _ProdutoRepository = new ProdutoRepository(Context);
                }

                return _ProdutoRepository;
            }
        }

        public ICompraRepository CompraRepository
        {
            get
            {
                if (_CompraRepository == null)
                {
                    _CompraRepository = new CompraRepository(Context);
                }

                return _CompraRepository;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}