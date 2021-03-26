using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class GroupsRepo : IRepository<Group>
    {
        public GroupsRepo(MyContext context) : base(context) { }


        public override void Create(Group item)
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

        public override void Delete(Group item)
        {
            throw new NotImplementedException();
        }

        public Group Get(int id)
        {
            throw new NotImplementedException();
        }
        public override Group Get(Func<Group, bool> func)
        {
            return db.Groups
                .Include(g=>g.StudentsGroupHistories)
                .FirstOrDefault(func);
        }

        public IEnumerable<Attendance> GetAll()
        {
            throw new NotImplementedException();
            //return db.AuthUsers;
        }
        public override IEnumerable<Group> GetAll(Func<Group, bool> func)
        {
            return db.Groups.Where(func);
        }

        public override Group OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Group item)
        {
            throw new NotImplementedException();
        }
    }
}