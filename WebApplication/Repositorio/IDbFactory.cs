using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public class DbFactory : IDbFactory
    {
        ApplicationContext agratContext;

        public ApplicationContext Init()
        {
            return agratContext ?? (agratContext = new ApplicationContext());
        }
    }

    public interface IDbFactory
    {
        ApplicationContext Init();
    }
}