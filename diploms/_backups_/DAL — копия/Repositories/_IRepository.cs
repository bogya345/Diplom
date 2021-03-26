using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL.Contexts;

namespace hod_back.DAL.Repositories
{

    public abstract class IRepository<T> where T : class
    {
        protected Context db;

        public IRepository(Context context)
        {
            this.db = context;
        }

        public virtual IEnumerable<T> GetMany(Func<T, bool> func) { throw new NotImplementedException(); }

        public virtual T Get(Func<T, bool> func) { throw new NotImplementedException(); }
        public virtual T OnExist(string name) { throw new NotImplementedException(); }

        public virtual void Create(T item) { }

        public virtual void Update(T item) { }

        public virtual void Delete(int itemId) { }
        public virtual void Delete(string itemName) { }
        public virtual void Delete(T item) { }
    }

}
