using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class SubjectForGroupRepo : IRepository<SubjectForGroup>
    {
        public SubjectForGroupRepo(MyContext context) : base(context) { }


        public override void Create(SubjectForGroup item)
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

        public override void Delete(SubjectForGroup item)
        {
            throw new NotImplementedException();
        }

        public SubjectForGroup Get(int id)
        {
            throw new NotImplementedException();
        }
        public override SubjectForGroup Get(Func<SubjectForGroup, bool> func)
        {
            return db.SubjectForGroups
                .Include(sfg=>sfg.ExactClasses)
                .Include(sfg=>sfg.Lecturer)
                .Include(sfg=>sfg.Group)
                .FirstOrDefault(func);
        }

        public IEnumerable<SubjectForGroup> GetAll()
        {
            throw new NotImplementedException();
            //return db.AuthUsers;
        }
        public override IEnumerable<SubjectForGroup> GetAll(Func<SubjectForGroup, bool> func)
        {
            return db.SubjectForGroups.Where(func);
        }

        public override SubjectForGroup OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(SubjectForGroup item)
        {
            throw new NotImplementedException();
        }
    }

}
