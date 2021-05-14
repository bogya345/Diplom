using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class TeacherDepRepository : IRepository<TeacherDep>
    {
        public TeacherDepRepository(Context context) : base(context) { }


        public override void Create(TeacherDep item) { db.TeacherDeps.Add(item); }
        //public override TeacherDep CreateWithReturn(TeacherDep item)
        //{
        //    db.TeacherDeps.Add(item);
        //    db.SaveChanges();
        //    return item;
        //}
        public override void CreateRange(TeacherDep[] items) { db.TeacherDeps.AddRange(items); db.SaveChanges(); }

        public override IEnumerable<TeacherDep> GetAll()
        {
            return db.TeacherDeps;
        }
        public override async Task<IEnumerable<TeacherDep>> GetAllAsync()
        {
            var tmp = db.TeacherDeps;

            IEnumerable<TeacherDep> GetData()
            {
                foreach (var i in tmp)
                    yield return i;
            }

            return GetData();
        }

        public override IEnumerable<TeacherDep> GetMany(Func<TeacherDep, bool> func)
        {
            return db.TeacherDeps.Where(func);
        }

        //public override IEnumerable<TeacherDep> GetManyWithInclude(Func<TeacherDep, bool> func)
        //{
        //    return db.TeacherDeps
        //        .Include(x => x.Subjects)
        //        //.ThenInclude(y => y.)
        //        .Include(x => x.Dep)
        //        .Where(func);
        //}

        //public override void UpdateRange(TeacherDep[] items)
        //{
        //    foreach (var i in items)
        //    {
        //        var tmp = db.TeacherDeps.FirstOrDefault(x => x.AcPlDepId == i.AcPlDepId);
        //        tmp.DepId = i.DepId;
        //        db.AcPlanDeps.Update(tmp);
        //    }
        //    //db.UpdateRange(items);
        //    db.SaveChanges();
        //}

        //public override void DeleteRange(BlockNum[] items)
        //{
        //    db.RemoveRange(items)
        //}

    }
}
