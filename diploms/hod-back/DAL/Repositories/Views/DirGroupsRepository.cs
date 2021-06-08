using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Repositories
{
    public class DirGroupsRepository : IRepository<DirGroup>
    {
        public DirGroupsRepository(Context context) : base(context) { }

        public override IEnumerable<DirGroup> GetMany(Func<DirGroup, bool> func)
        {
            try
            {
                return db.DirGroups.Where(func);
            }
            catch(InvalidOperationException ex)
            {
                return new Context().DirGroups.Where(func);
            }
        }
        public async override Task<IEnumerable<DirGroup>> GetManyAsync(Func<DirGroup, bool> func)
        {
            mark:
            try
            {
                return db.DirGroups.Where(func).ToList();
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }
        public IEnumerable<DirGroup> GetAll()
        {
            return db.DirGroups;
        }
        //public override 
    }
}
