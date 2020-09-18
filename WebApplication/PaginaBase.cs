using System.Web.UI;
using WebApplication.Repositorio;

namespace WebApplication
{
    public class PaginaBase : Page
    {
        protected UnitOfWork Uow = new UnitOfWork();
    }
}