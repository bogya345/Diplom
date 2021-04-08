using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class EmployeesRepository : IRepository<Employee>
    {
        public EmployeesRepository(Context context) : base(context) { }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }
        public override Employee GetOrDefault(Func<Employee, bool> func, Employee def = null)
        {
            return db.Employees.FirstOrDefault(func);
        }


        public override void Create(Employee item)
        {
            db.Employees.Add(item);
        }

        public override void Update(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public override void Delete(int itemId)
        {
            Employee book = db.Employees.Find(itemId);
            if (book != null)
                db.Employees.Remove(book);
        }


        public IEnumerable<Employee> GetAll()
        {
            // нельзя вот так взять и выгрузить всех преподавателей, ты уверен что оно тебе надо???
            // подумай еще раз
            throw new NotImplementedException();
        }
        public override IEnumerable<Employee> GetMany(Func<Employee, bool> func)
        {
            return db.Employees.Where(func);
        }
        public IEnumerable<Employee> GetAllTeachers()
        {
            // всех кроме тех кто в отделах 5(УМУ) и 6(ИВЦ)
            //return db.Employees.Where(x => x.dep != 5 && x.id_department != 6);
            throw new NotImplementedException();
            // need to find department ID in other way
        }
    }
}
