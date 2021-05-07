using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class StudyYearsRepo : IRepository<StudyYear>
    {
        public StudyYearsRepo(MyContext context) : base(context) { }


        public override void Create(StudyYear item)
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

        public override void Delete(StudyYear item)
        {
            throw new NotImplementedException();
        }

        public StudyYear Get(int id)
        {
            return db.StudyYears

                .FirstOrDefault(sy=>sy.IdStudyYear==id);
        }
        public override StudyYear Get(Func<StudyYear, bool> func)
        {
            return db.StudyYears
 
                .FirstOrDefault(func);
        }

        public IEnumerable<StudyYear> GetAll()
        {
            //List<StudyYear> tmp = new List<StudyYear>();
            //tmp = db.StudentsGroupHistories
            //    .Include(sgh => sgh.Group)
            //    .Include(sgh => sgh.Course)
            //    //.Include(sgh => sgh.Attendances)
            //    //.Include(sgh => sgh.Student)
            //    .ToList();
            return db.StudyYears;
                               
            //return db.AuthUsers;
        }
        public override IEnumerable<StudyYear> GetAll(Func<StudyYear, bool> func)
        {
            return db.StudyYears
                .Where(func);
        }

        public override StudyYear OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(StudyYear item)
        {
            throw new NotImplementedException();
        }
    }
}
