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
    public class TeacherLoadRepository : IRepository<TeacherLoad>
    {
        public TeacherLoadRepository(Context context) : base(context) { }


        public TeacherLoad Get(int id)
        {
            return db.TeacherLoad.Find(id);
        }
        public override TeacherLoad Get(Func<TeacherLoad, bool> func)
        {
            return db.TeacherLoad.FirstOrDefault(func);
        }

        public override TeacherLoad OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Create(TeacherLoad item)
        {
            db.TeacherLoad.Add(item);
        }

        public override void Update(TeacherLoad item)
        {
            //db.Entry(book).State = EntityState.Modified;
            db.TeacherLoad
                .Where(x => (x.id_blockRec == item.id_blockRec))
                .ToList()
                .Where(y => (y.typeSubject.Trim(' ').ToLower() == item.typeSubject.Trim(' ').ToLower()))
                .FirstOrDefault()
                .id_employee = item.id_employee;
        }

        public override void Delete(int itemId)
        {
            TeacherLoad book = db.TeacherLoad.Find(itemId);
            if (book != null)
                db.TeacherLoad.Remove(book);
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TeacherLoad item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeacherLoad> GetAll()
        {
            throw new NotImplementedException();
            //return db.TeacherLoad;
        }
        public override IEnumerable<TeacherLoad> GetAll(Func<TeacherLoad, bool> func)
        {
            return db.TeacherLoad.Where(func);
        }
    }
}
