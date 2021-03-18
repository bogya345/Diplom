using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;

using hod_back.DAL.Contexts;

namespace hod_back.DAL.Repositories
{
    public class GroupsRepository : IRepository<Groups>
    {
        public GroupsRepository(Context context) : base(context) { }


        public override void Create(Groups item)
        {
            db.Groups.Add(item);
        }

        public override void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Groups item)
        {
            throw new NotImplementedException();
        }

        public Groups Get(int id)
        {
            return db.Groups.Where(x => x.id_group == id).FirstOrDefault();
        }
        public override Groups Get(Func<Groups, bool> func)
        {
            return db.Groups.FirstOrDefault(func);
        }

        public IEnumerable<Groups> GetAll()
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Groups> GetMany(Func<Groups, bool> func)
        {
            if (DAL_Settings.localAccess)
            {
                return LocalStorage.groups.Where(func);
            }
            return db.Groups.Where(func);
        }

        public override Groups OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Groups item)
        {
            throw new NotImplementedException();
        }
    }
}
