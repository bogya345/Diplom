using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class ExactClassesRepo:IRepository<ExactClass>
	{
        public ExactClassesRepo(MyContext context) : base(context) { }


        public override void Create(ExactClass item)
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

        public override void Delete(ExactClass item)
        {
            throw new NotImplementedException();
        }

        public ExactClass Get(int id)
        {
            throw new NotImplementedException();
        }
        public override ExactClass Get(Func<ExactClass, bool> func)
        {
            return db.ExactClasses
                .Include(ec=>ec.PersonLecturer)
                .FirstOrDefault(func);
        }

        public IEnumerable<ExactClass> GetAll()
        {
            return db.ExactClasses
                .Include(ex => ex.PersonLecturer)
                .Include(ex => ex.Auditory);
            //return db.AuthUsers;
        }
        public override IEnumerable<ExactClass> GetAll(Func<ExactClass, bool> func)
        {
            return db.ExactClasses
                .Include(ex=>ex.PersonLecturer)
                .Include(ex=>ex.Auditory)
                .Where(func);
        }

        public override ExactClass OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(ExactClass item)
        {
            throw new NotImplementedException();
        }
    }
}
