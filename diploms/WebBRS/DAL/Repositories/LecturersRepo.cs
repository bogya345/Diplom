using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class LecturersRepo    : IRepository<Lecturer>
    {
        public LecturersRepo(MyContext context) : base(context) { }


        public override void Create(Lecturer item)
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

        public override void Delete(Lecturer item)
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }
        public override Lecturer Get(Func<Lecturer, bool> func)
        {
            return db.Lectureres
                .Include(l => l.Subjects)
                .Include(l => l.Person)
                .Include(l => l.SubjectForGroups)
                .Include(l=>l.ExactClasses)
                .FirstOrDefault(func);
        }

        public IEnumerable<Lecturer> GetAll()
        {
            //throw new NotImplementedException();
            IEnumerable<Student> tmp = db.Students;

            return db.Lectureres.ToList();

        }
        public override IEnumerable<Lecturer> GetAll(Func<Lecturer, bool> func)
        {
            return db.Lectureres.Where(func);
        }

        public override Lecturer OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Lecturer item)
        {
            throw new NotImplementedException();
        }
    }
}
