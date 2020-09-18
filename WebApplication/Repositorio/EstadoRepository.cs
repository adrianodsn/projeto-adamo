
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication.Entities;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        readonly ApplicationContext Context;

        public EstadoRepository(ApplicationContext context) : base(context)
        {
            Context = context;
        }

        public Estado ObterEstadoIncludeCidades(int id)
        {
            return Context.Estados
                .Include(x => x.Cidades)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Estado> BuscarEstadosPorNome(string q)
        {
            IQueryable<Estado> estados = Context.Estados
                .AsNoTracking()
                .OrderBy(x => x.Nome);

            if (!string.IsNullOrEmpty(q))
            {
                estados = estados.Where(x => x.Nome.Contains(q));
            }

            return estados.ToList();
        }
    }

}