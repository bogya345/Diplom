using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using hod_back.DAL.Contexts;
using hod_back.Model;

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
        public virtual IEnumerable<T> GetManyWithInclude(Func<T, bool> func) { throw new NotImplementedException(); }

        public virtual IEnumerable<T> GetAll() { throw new NotImplementedException(); }

        public virtual T GetOrDefault(Func<T, bool> func, T def = null) { throw new NotImplementedException(); }
        public virtual T OnExist(string name) { throw new NotImplementedException(); }

        public virtual void Create(T item) { }
        public virtual T CreateWithReturn(T item) { return item; }

        /// <summary>
        /// Ты можешь это использовать, но убедись что ты не закинешь дубли
        /// </summary>
        /// <param name="items"></param>
        public virtual void CreateRange(T[] items) { }

        public virtual void Update(T item) { }
        public virtual void UpdateRange(T[] items) { }

        public virtual void Delete(int itemId) { }
        public virtual void Delete(string itemName) { }
        public virtual void Delete(T item) { }
        public virtual void DeleteRange(T[] items) { }
    }

}
