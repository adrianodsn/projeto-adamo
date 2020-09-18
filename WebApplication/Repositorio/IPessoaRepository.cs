using System;
using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repositorio
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        List<Pessoa> BuscarPessoas(string q, string cpf, DateTime? dataIni, DateTime? dataFim);
    }
}
