using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository
{
    public class BaseDataContext<DContext> : IBaseDataContext, IDisposable where DContext : DbContext, new()
    {
        private DContext _DContext;
        public BaseDataContext()
        {
            _DContext = new DContext();
        }

        protected DContext _TContext
        {
            get { return _DContext; }
        }

        public int SaveChanges()
        {
            return _DContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool _bool)
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}