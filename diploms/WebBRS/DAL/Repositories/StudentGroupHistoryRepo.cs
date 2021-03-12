using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class StudentGroupHistoryRepo : IRepository<StudentsGroupHistory>
    {
        public StudentGroupHistoryRepo(MyContext context) : base(context) { }


        public override void Create(StudentsGroupHistory item)
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

        public override void Delete(StudentsGroupHistory item)
        {
            throw new NotImplementedException();
        }

        public StudentsGroupHistory Get(int id)
        {
            throw new NotImplementedException();
        }
        public override StudentsGroupHistory Get(Func<StudentsGroupHistory, bool> func)
        {
            return db.StudentsGroupHistories.FirstOrDefault(func);
        }

        public IEnumerable<StudentsGroupHistory> GetAll()
        {
            throw new NotImplementedException();
            //return db.AuthUsers;
        }
        public override IEnumerable<StudentsGroupHistory> GetAll(Func<StudentsGroupHistory, bool> func)
        {
            return db.StudentsGroupHistories.Where(func);
        }

        public override StudentsGroupHistory OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(StudentsGroupHistory item)
        {
            throw new NotImplementedException();
        }
    }
}
