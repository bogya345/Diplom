using Microsoft.EntityFrameworkCore;
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
            return db.StudentsGroupHistories
                .Include(sgh=>sgh.Student)
                .Include(sgh=>sgh.Attendances)
                .FirstOrDefault(func);
        }

        public IEnumerable<StudentsGroupHistory> GetAll()
        {
            List < StudentsGroupHistory > tmp  = new List<StudentsGroupHistory>();
            tmp=  db.StudentsGroupHistories
				.Include(sgh => sgh.Group)
				.Include(sgh => sgh.Course)
				//.Include(sgh => sgh.Attendances)
				//.Include(sgh => sgh.Student)
				.ToList();
            return db.StudentsGroupHistories
                                .Include(sgh => sgh.Group)
                .Include(sgh => sgh.Course)
                //.Include(sgh => sgh.Attendances)
                .Include(sgh => sgh.Student);
            //return db.AuthUsers;
        }
        public override IEnumerable<StudentsGroupHistory> GetAll(Func<StudentsGroupHistory, bool> func)
        {
            return db.StudentsGroupHistories
				.Include(sgh => sgh.Group)
				.Include(sgh => sgh.Course)
				//.Include(sgh => sgh.Attendances)
                .Include(sgh=>sgh.Student)
				.Where(func);
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
