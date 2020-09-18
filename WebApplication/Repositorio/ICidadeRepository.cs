using System.Collections.Generic;
using WebApplication.Entities;

namespace WebApplication.Repositorio
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        List<Cidade> BuscarCidadesPorNomeEEstado(string q, int estadoId);
    }
}
