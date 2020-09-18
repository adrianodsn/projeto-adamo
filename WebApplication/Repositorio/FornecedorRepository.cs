
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        readonly ApplicationContext Context;

        public FornecedorRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public List<Fornecedor> BuscarFornecedores(string nome, string cnpj)
        {
            IQueryable<Fornecedor> fornecedores = Context.Fornecedores
                .AsNoTracking()
                .OrderBy(x => x.Nome);

            if (!string.IsNullOrEmpty(nome))
            {
                fornecedores = fornecedores.Where(x => x.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(cnpj))
            {
                fornecedores = fornecedores.Where(x => x.Cnpj == cnpj);
            }

            return fornecedores.ToList();
        }
    }

}