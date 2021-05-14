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
        object lockVar = new object();
        protected Context db;

        public IRepository(Context context)
        {
            this.db = context;
        }

        protected Context GetDbAsync()
        {
            return _db().Result;
        }

        protected async Task<Context> _db()
        {
            lock (lockVar)
            {
                return db;
            }
        }

        public virtual IEnumerable<T> GetMany(Func<T, bool> func) { throw new NotImplementedException(); }
        public virtual IEnumerable<T> GetManyWithInclude(Func<T, bool> func) { throw new NotImplementedException(); }

        public virtual IEnumerable<T> GetAll() { throw new NotImplementedException(); }

        public virtual T GetOrDefault(Func<T, bool> func, T def = null) { throw new NotImplementedException(); }
        public virtual T GetOrDefaultWithInclude(Func<T, bool> func, T def = null) { throw new NotImplementedException(); }
        public virtual T OnExist(string name) { throw new NotImplementedException(); }
        public virtual bool OnExist(Func<T, bool> func) { throw new NotImplementedException(); }

        public virtual void Create(T item) { throw new NotImplementedException(); }
        public virtual T CreateWithReturn(T item) { throw new NotImplementedException(); }

        /// <summary>
        /// Ты можешь это использовать, но убедись что ты не закинешь дубли
        /// </summary>
        /// <param name="items"></param>
        public virtual void CreateRange(T[] items) { throw new NotImplementedException(); }

        public virtual void Update(T item) { throw new NotImplementedException(); }
        public virtual void UpdateRange(T[] items) { throw new NotImplementedException(); }

        public virtual void Delete(int itemId) { throw new NotImplementedException(); }
        public virtual void Delete(string itemName) { throw new NotImplementedException(); }
        public virtual void Delete(T item) { throw new NotImplementedException(); }
        public virtual void DeleteRange(T[] items) { throw new NotImplementedException(); }

        #region Под ассинхронность
        public virtual async Task<IEnumerable<T>> GetManyAsync(Func<T, bool> func) { throw new NotImplementedException(); }
        public virtual async Task<IEnumerable<T>> GetManyWithIncludeAsync(Func<T, bool> func) { throw new NotImplementedException(); }

        public virtual async Task<IEnumerable<T>> GetAllAsync() { throw new NotImplementedException(); }

        public virtual async Task<T> GetOrDefaultAsync(Func<T, bool> func, T def = null) { throw new NotImplementedException(); }
        public virtual async Task<T> GetOrDefaultWithIncludeAsync(Func<T, bool> func, T def = null) { throw new NotImplementedException(); }
        public virtual async Task<T> OnExistAsync(string name) { throw new NotImplementedException(); }

        //public virtual async void Create(T item) { }
        public virtual async Task<T> CreateWithReturnAsync(T item) { throw new NotImplementedException(); }

        public virtual async void CreateAsync(T item) { throw new NotImplementedException(); }
        /// <summary>
        /// Ты можешь это использовать, но убедись что ты не закинешь дубли
        /// </summary>
        /// <param name="items"></param>
        public virtual async void CreateRangeAsync(T[] items) { throw new NotImplementedException(); }

        public virtual async void UpdateAsync(T item) { throw new NotImplementedException(); }
        public virtual async void UpdateRangeAsync(T[] items) { throw new NotImplementedException(); }

        //public virtual async void Delete(int itemId) { }
        //public virtual async void Delete(string itemName) { }
        //public virtual async void Delete(T item) { }
        //public virtual async void DeleteRange(T[] items) { }
        #endregion
    }

}
