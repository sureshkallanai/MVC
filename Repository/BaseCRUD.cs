using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Repository
{
    public class BaseCRUD<T, DContext> : IBaseCRUD<T> where T : class where DContext : DbContext
    {
        private DbSet<T> _Dbset;
        private DContext _Dcontext;
        public BaseCRUD(DContext _dcontext)
        {
            _Dcontext = _dcontext;
            _Dbset = _Dcontext.Set<T>();
        }

        public void Add(T _T)
        {
            _Dcontext.Entry(_T).State = EntityState.Added;
        }


        public void Delete(T _T)
        {
            _Dcontext.Entry(_T).State = EntityState.Deleted;
        }

        public ICollection<T> Get()
        {
            return _Dbset.ToList();
        }

        public void Update(T _T)
        {
            _Dcontext.Entry(_T).State = EntityState.Modified;
        }

        public void DeleteFindByID(int id)
        {
            T _T = _Dbset.Find(id);
            Delete(_T);
        }

        public IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children)
        {
            return _Dbset.Include(children).Where(filter);
        }
    }
}