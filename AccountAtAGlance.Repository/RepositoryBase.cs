using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public class RepositoryBase<C>: IDisposable where C: DbContext, new()
    {
        private C _DataContext;

        public virtual C DataContext
        {
            get
            {
                if (_DataContext == null)
                {
                    _DataContext = new C();
                    this.AllowSerialization = true;
                }
                return _DataContext;
            }


        }

        public virtual bool AllowSerialization
        {
            get
            {
                return _DataContext.Configuration.ProxyCreationEnabled;
            }
            set
            {
                _DataContext.Configuration.ProxyCreationEnabled = !value;
            }
        }

        //public virtual T Get<T>(Expression<Func<T, bool>> predicate) where T: 

        public void Dispose()
        {
            if (DataContext != null) DataContext.Dispose();
        }
    }
}
