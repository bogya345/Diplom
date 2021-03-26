using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class TeacherLoadRepository : IRepository<TeacherLoad>
    {
        public TeacherLoadRepository(Context context) : base(context) { }


        public TeacherLoad Get(int id)
        {
            return db.TeacherLoads.Find(id);
        }
        public override TeacherLoad Get(Func<TeacherLoad, bool> func)
        {
            return db.TeacherLoads.FirstOrDefault(func);
        }

        public override TeacherLoad OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Create(TeacherLoad item)
        {
            db.TeacherLoads.Add(item);
        }

        public override void Update(TeacherLoad item)
        {
            //db.Entry(book).State = EntityState.Modified;
            db.TeacherLoads
                .Where(x => (x.BlocRecId == item.BlocRecId))
                .ToList()
                .Where(y => (y.SubType.SubTypeName.Trim(' ').ToLower() == item.SubType.SubTypeName.Trim(' ').ToLower()))
                .FirstOrDefault()
                .FshId = item.FshId;
        }

        public override void Delete(int itemId)
        {
            TeacherLoad book = db.TeacherLoads.Find(itemId);
            if (book != null)
                db.TeacherLoads.Remove(book);
        }

        public IEnumerable<TeacherLoad> GetAll()
        {
            throw new NotImplementedException();
            //return db.TeacherLoad;
        }

        public override IEnumerable<TeacherLoad> GetMany(Func<TeacherLoad, bool> func)
        {
            return db.TeacherLoads.Where(func);
        }
    }
}
