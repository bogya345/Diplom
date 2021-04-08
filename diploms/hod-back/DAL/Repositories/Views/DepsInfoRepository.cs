using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Repositories
{
    public class DepsInfoRepository : IRepository<DepsInfo>
    {
        public DepsInfoRepository(Context context) : base(context) { }

        public override IEnumerable<DepsInfo> GetMany(Func<DepsInfo, bool> func)
        {
            return db.DepsInfos.Where(func);
        }
        public IEnumerable<DepsInfo> GetAll()
        {
            return db.DepsInfos;
        }
        //public override 
    }
}
