using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Repositories
{
    public class DepDirFacRepository : IRepository<DepDirFac>
    {
        public DepDirFacRepository(Context context) : base(context) { }

        public override IEnumerable<DepDirFac> GetMany(Func<DepDirFac, bool> func)
        {
            return db.DepDirFacs.Where(func);
        }
        public IEnumerable<DepDirFac> GetAll() { return db.DepDirFacs; }
        public async Task<IEnumerable<DepDirFac>> GetAllAsync()
        {
            try
            {
                var tmp = db.DepDirFacs.ToListAsync();
                return tmp.Result;

                //IEnumerable<DepDirFac> GetData()
                //{
                //    foreach (var i in tmp)
                //        yield return i;
                //}

                //return GetData();
            }
            catch(InvalidOperationException ex)
            {
                var tmp = new Context().DepDirFacs.ToList();
                return tmp;
            }
        }
        //public override 

        public override DepDirFac GetOrDefault(Func<DepDirFac, bool> func, DepDirFac def = null)
        {
            return db.DepDirFacs.FirstOrDefault(func) ?? def;
        }
    }
}
