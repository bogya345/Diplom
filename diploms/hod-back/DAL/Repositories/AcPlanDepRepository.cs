using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class AcPlanDepRepository : IRepository<AcPlanDep>
    {
        public AcPlanDepRepository(Context context) : base(context) { }


        public override void Create(AcPlanDep item) { db.AcPlanDeps.Add(item); }
        public override AcPlanDep CreateWithReturn(AcPlanDep item)
        {
            db.AcPlanDeps.Add(item);
            db.SaveChanges();
            return item;
        }
        public override void CreateRange(AcPlanDep[] items) { db.AddRange(items); db.SaveChanges(); }

        public override IEnumerable<AcPlanDep> GetAll()
        {
            return db.AcPlanDeps;
        }
        public override async Task<IEnumerable<AcPlanDep>> GetAllAsync()
        {
            var tmp = db.AcPlanDeps;

            IEnumerable<AcPlanDep> GetData()
            {
                foreach (var i in tmp)
                    yield return i;
            }

            return GetData();
        }

        public override IEnumerable<AcPlanDep> GetMany(Func<AcPlanDep, bool> func)
        {
            return db.AcPlanDeps.Where(func);
        }

        public override IEnumerable<AcPlanDep> GetManyWithInclude(Func<AcPlanDep, bool> func)
        {
            return db.AcPlanDeps
                .Include(x => x.Subjects)
                //.ThenInclude(y => y.)
                .Include(x => x.Dep)
                .Where(func);
        }

        public override void UpdateRange(AcPlanDep[] items)
        {
            foreach(var i in items)
            {
                var tmp = db.AcPlanDeps.FirstOrDefault(x => x.AcPlDepId == i.AcPlDepId);
                tmp.DepId = i.DepId;
                db.AcPlanDeps.Update(tmp);
            }
            //db.UpdateRange(items);
            db.SaveChanges();
        }

        //public override void DeleteRange(BlockNum[] items)
        //{
        //    db.RemoveRange(items)
        //}

    }
}
