using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Repositories
{
    public class DepDirFacRepository : IRepository<DepDirFac>
    {
        public DepDirFacRepository(Context context) : base(context) { }

        public override IEnumerable<DepDirFac> GetMany(Func<DepDirFac, bool> func)
        {
            return db.DepDirFacs.Where(func);
        }
        public IEnumerable<DepDirFac> GetAll()
        {
            return db.DepDirFacs;
        }
        //public override 

        public override DepDirFac GetOrDefault(Func<DepDirFac, bool> func, DepDirFac def = null)
        {
            return db.DepDirFacs.FirstOrDefault(func) ?? def;
        }
    }
}
