using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        readonly ApplicationContext Context;

        public CidadeRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public List<Cidade> BuscarCidadesPorNomeEEstado(string q, int estadoId)
        {
            IQueryable<Cidade> cidades = Context.Cidades
            .Include(x => x.Estado)
            .AsNoTracking()
            .OrderBy(x => x.Nome);

            if (!string.IsNullOrEmpty(q))
            {
                cidades = cidades.Where(x => x.Nome.Contains(q));
            }

            if (!estadoId.Equals(0))
            {
                cidades = cidades.Where(x => x.EstadoId == estadoId);
            }

            return cidades.ToList();
        }
    }
}