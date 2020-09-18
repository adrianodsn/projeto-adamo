
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        readonly ApplicationContext Context;

        public PessoaRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public List<Pessoa> BuscarPessoas(string q, string cpf, DateTime? dataIni, DateTime? dataFim)
        {
            IQueryable<Pessoa> pessoas = Context.Pessoas
                .AsNoTracking()
                .OrderBy(x => x.Nome);

            if (!string.IsNullOrEmpty(q))
            {
                pessoas = pessoas.Where(x => x.Nome.Contains(q));
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                pessoas = pessoas.Where(x => x.Cpf == cpf);
            }

            if (dataIni != null)
            {
                pessoas = pessoas.Where(x => x.DataNascimento >= dataIni);
            }

            if (dataFim != null)
            {
                pessoas = pessoas.Where(x => x.DataNascimento <= dataFim);
            }

            return pessoas.ToList();
        }
    }

}