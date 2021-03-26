using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;
using hod_back.DAL.Models.Views;

using hod_back.DAL.Contexts;
using hod_back.DAL.Models.Auth;

namespace hod_back.DAL.Repositories.Auth
{
    public class RolesRepository : IRepository<Roles>
    {
        public RolesRepository(Context context) : base(context) { }

        public override void Create(Roles item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Roles item)
        {
            throw new NotImplementedException();
        }

        public override Roles Get(Func<Roles, bool> func)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Roles> GetMany(Func<Roles, bool> func)
        {
            throw new NotImplementedException();
        }

        public override Roles OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Roles item)
        {
            throw new NotImplementedException();
        }
    }
}
