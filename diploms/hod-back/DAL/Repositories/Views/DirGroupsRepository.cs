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
        public IEnumerable<DirGroup> GetAll()
        {
            return db.DirGroups;
        }
        //public override 
    }
}
