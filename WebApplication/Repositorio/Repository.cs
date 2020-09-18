using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WebApplication.Infra.Context;

namespace WebApplication.Repositorio
{
    public abstract class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly ApplicationContext Context;

        public Repository(ApplicationContext context)
        {
            Context = context;

            Context.Configuration.LazyLoadingEnabled = false;
            Context.Configuration.ProxyCreationEnabled = false;
        }

        public List<T> ObterTodos()
        {
            return Context.Set<T>().ToList();
        }

        public List<T> Obter(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T Procurar(params object[] key)
        {
            return Context.Set<T>().Find(key);
        }

        public T Primeiro(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void Adicionar(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Deletar(Func<T, bool> predicate)
        {
            Context.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => Context.Set<T>().Remove(del));
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}