using System;
using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repositorio
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        List<Fornecedor> BuscarFornecedores(string nome, string cnpj);
    }
}
