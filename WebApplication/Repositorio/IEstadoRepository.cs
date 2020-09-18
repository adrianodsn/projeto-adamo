using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repositorio
{
    public interface IEstadoRepository : IRepository<Estado>
    {
        Estado ObterEstadoIncludeCidades(int id);
        List<Estado> BuscarEstadosPorNome(string q);
    }
}
