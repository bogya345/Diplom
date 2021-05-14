using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class GroupsRepository : IRepository<Group>
    {
        public GroupsRepository(Context context) : base(context) { }


        public override void Create(Group item)
        {
            db.Groups.Add(item);
        }

        public Group Get(int id)
        {
            return db.Groups.Where(x => x.GroupId == id).FirstOrDefault();
        }
        public override Group GetOrDefault(Func<Group, bool> func, Group def = null)
        {
            return db.Groups.FirstOrDefault(func);
        }

        public override IEnumerable<Group> GetMany(Func<Group, bool> func)
        {
            return db.Groups.Where(func);
        }

        public override async Task<IEnumerable<Group>> GetManyAsync(Func<Group, bool> func)
        {
            try
            {
                var tmp = await db.Groups.ToListAsync();
                var res = tmp.Where(func);
                return res;
            }
            catch(InvalidOperationException ex)
            {
                var res = new Context().Groups.Where(func);
                return res;
            }
        }

        public override Group OnExist(string name)
        {
            throw new NotImplementedException();
        }

    }
}
