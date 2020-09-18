using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApplication.Repositorio
{
    public interface IRepository<T> where T : class
    {
        List<T> ObterTodos();
        List<T> Obter(Expression<Func<T, bool>> predicate);
        T Procurar(params object[] key);
        T Primeiro(Expression<Func<T, bool>> predicate);
        void Adicionar(T entity);
        void Deletar(Func<T, bool> predicate);
        void Dispose();
    }
}
