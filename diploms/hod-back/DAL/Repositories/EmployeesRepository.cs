using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;

using hod_back.DAL.Contexts;

namespace hod_back.DAL.Repositories
{
    public class EmployeesRepository : IRepository<Employees>
    {
        public EmployeesRepository(Context context) : base(context) { }

        public Employees Get(int id)
        {
            return db.Employees.Find(id);
        }
        public override Employees Get(Func<Employees, bool> func)
        {
            return db.Employees.FirstOrDefault(func);
        }

        public override Employees OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Create(Employees item)
        {
            db.Employees.Add(item);
        }

        public override void Update(Employees item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public override void Delete(int itemId)
        {
            Employees book = db.Employees.Find(itemId);
            if (book != null)
                db.Employees.Remove(book);
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Employees item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employees> GetAll()
        {
            // нельзя вот так взять и выгрузить всех преподавателей, ты уверен что оно тебе надо???
            // подумай еще раз
            throw new NotImplementedException();
        }
        public override IEnumerable<Employees> GetAll(Func<Employees, bool> func)
        {
            return db.Employees.Where(func);
        }
        public IEnumerable<Employees> GetAllTeachers()
        {
            // всех кроме тех кто в отделах 5(УМУ) и 6(ИВЦ)
            return db.Employees.Where(x => x.id_department != 5 && x.id_department != 6);
        }
    }
}
