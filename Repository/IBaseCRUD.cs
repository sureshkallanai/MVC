using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    public interface IBaseCRUD<T>
    {
        void Add(T _T);
        void Update(T _T);
        ICollection<T> Get();
        void Delete(T _T);
        void DeleteFindByID(int id);
        IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children);
    }
}