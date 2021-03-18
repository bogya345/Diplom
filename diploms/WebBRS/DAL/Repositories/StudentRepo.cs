using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
    public class StudentRepo : IRepository<Student>
    {
        public StudentRepo(MyContext context) : base(context) { }


        public override void Create(Student item)
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

        public override void Delete(Student item)
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }
        public override Student Get(Func<Student, bool> func)
        {
            return db.Students
                .Include(st=>st.Person)
                .Include(st=>st.StudentsGroupHistories)
                .FirstOrDefault(func);
        }

        public IEnumerable<Student> GetAll()
        {
            //throw new NotImplementedException();
            IEnumerable<Student> tmp = db.Students;

            return db.Students.ToList();

        }
        public override IEnumerable<Student> GetAll(Func<Student, bool> func)
        {
            return db.Students.Where(func);
        }

        public override Student OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Student item)
        {
            throw new NotImplementedException();
        }
    }
}
