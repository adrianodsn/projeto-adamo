
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        readonly ApplicationContext Context;

        public ProdutoRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public List<Produto> BuscarProdutos(string descricao)
        {
            IQueryable<Produto> produtos = Context.Produtos
                .AsNoTracking()
                .OrderBy(x => x.Descricao);

           if (!string.IsNullOrEmpty(descricao))
            {
                produtos = produtos.Where(x => x.Descricao.Contains(descricao));
            }

            return produtos.ToList();
        }
    }

}