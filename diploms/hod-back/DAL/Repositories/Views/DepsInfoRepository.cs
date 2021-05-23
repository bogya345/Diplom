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

        public override async Task<DepsInfo> GetOrDefaultAsync(Func<DepsInfo, bool> func, DepsInfo def = null)
        {
        mark:
            try
            {
                return db.DepsInfos.FirstOrDefault(func);
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }

        public IEnumerable<DepsInfo> GetAll()
        {
            return db.DepsInfos;
        }

        public async override Task<IEnumerable<DepsInfo>> GetAllAsync()
        {
            mark:
            try
            {
                return db.DepsInfos.ToList();
            }
            catch(InvalidCastException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }
        //public override 
    }
}
