using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;
using WebBRS.Models.Auth;

namespace WebBRS.DAL.Repositories
{
	public class UsersRepo : IRepository<User>
	{
        public UsersRepo(MyContext context) : base(context) { }


        public override void Create(User item)
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

        public override void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }
        public override User Get(Func<User, bool> func)
        {
            return db.Users
                .Include(g => g.Role)
                .FirstOrDefault(func);
        }

        public IEnumerable<Attendance> GetAll()
        {
            throw new NotImplementedException();
            //return db.AuthUsers;
        }
        public override IEnumerable<User> GetAll(Func<User, bool> func)
        {
            return db.Users.Where(func);
        }

        public override User OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
