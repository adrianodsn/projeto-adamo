using System;
using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repositorio
{
    public interface IProdutoRepository : IRepository<Produto>
   {
       List<Produto> BuscarProdutos(string descricao);
    }
}
