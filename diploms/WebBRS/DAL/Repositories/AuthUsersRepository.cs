using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models.Views;

namespace WebBRS.DAL.Repositories
{
    public class AuthUsersRepository : IRepository<AuthUsers>
    {
        public AuthUsersRepository(MyContext context) : base(context) { }


        public override void Create(AuthUsers item)
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

        public override void Delete(AuthUsers item)
        {
            throw new NotImplementedException();
        }

        public AuthUsers Get(int id)
        {
            throw new NotImplementedException();
        }
        public override AuthUsers Get(Func<AuthUsers, bool> func)
        {
            return db.AuthUsers.FirstOrDefault(func);
        }

        public IEnumerable<AuthUsers> GetAll()
        {
            throw new NotImplementedException();
            //return db.AuthUsers;
        }
        public override IEnumerable<AuthUsers> GetAll(Func<AuthUsers, bool> func)
        {
            return db.AuthUsers.Where(func);
        }

        public override AuthUsers OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(AuthUsers item)
        {
            throw new NotImplementedException();
        }
    }
}
