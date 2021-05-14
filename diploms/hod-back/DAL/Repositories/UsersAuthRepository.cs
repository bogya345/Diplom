using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Auth;
using hod_back.DAL.Models.Views;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class AuthUsersRepository : IRepository<AuthUser>
    {
        public AuthUsersRepository(Context context) : base(context) { }

        public override AuthUser GetOrDefault(Func<AuthUser, bool> func, AuthUser def = null)
        {
            try
            {
                return db.AuthUsers.FirstOrDefault(func) ?? def;
            }
            catch(InvalidOperationException ex)
            {
                return new Context().AuthUsers.FirstOrDefault(func) ?? def;
            }
        }

        //public override AuthUser GetOrDefault(Func<AuthUser, bool> func)
        //{
        //    return db.AuthUsers.FirstOrDefault(func);
        //}

        public IEnumerable<AuthUser> GetAll()
        {
            throw new NotImplementedException();
            //return db.AuthUsers;
        }

        public override IEnumerable<AuthUser> GetMany(Func<AuthUser, bool> func)
        {
            return db.AuthUsers.Where(func);
        }

    }
}
