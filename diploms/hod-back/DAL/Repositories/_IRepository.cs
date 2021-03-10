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

        public abstract IEnumerable<T> GetAll(Func<T, bool> func);

        public abstract T Get(Func<T, bool> func);
        public abstract T OnExist(string name);

        public abstract void Create(T item);

        public abstract void Update(T item);

        public abstract void Delete(int itemId);
        public abstract void Delete(string itemName);
        public abstract void Delete(T item);
    }

}
