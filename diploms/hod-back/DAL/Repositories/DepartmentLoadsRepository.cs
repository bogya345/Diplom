using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class DepartmentLoadsRepository : IRepository<DepartmentLoad>
    {
        public DepartmentLoadsRepository(Context context) : base(context) { }


        public override void Create(DepartmentLoad item) { db.DepartmentLoads.Add(item); }
        public override DepartmentLoad CreateWithReturn(DepartmentLoad item)
        {
            db.DepartmentLoads.Add(item);
            db.SaveChanges();
            return item;
        }
        public override void CreateRange(DepartmentLoad[] items) { db.AddRange(items); db.SaveChanges(); }

        public override IEnumerable<DepartmentLoad> GetAll()
        {
            return db.DepartmentLoads;
        }

        public override IEnumerable<DepartmentLoad> GetMany(Func<DepartmentLoad, bool> func)
        {
            return db.DepartmentLoads.Where(func);
        }

        public override async Task<IEnumerable<DepartmentLoad>> GetManyAsync(Func<DepartmentLoad, bool> func)
        {
        mark:
            try
            {
                var tmp = db.DepartmentLoads.Where(func).ToList();
                return tmp;
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }

        public override IEnumerable<DepartmentLoad> GetManyWithInclude(Func<DepartmentLoad, bool> func)
        {
            //var tmp = db.AttachedAcPlans
            //    //.Include(x => x.Group)
            //    //.Include(x => x.BlockRec)
            //    //.Include(x => x.BlockRec.BlockNum)
            //    //.Include(x => x.BlockRec.Sub)
            //    .Where(func)
            //    ;

            var tmp = from attAcPl in db.DepartmentLoads
                      where attAcPl.GroupId == 9919
                      //orderby attAcPl.
                      select attAcPl
                      ;

            //var questionsWithInclude = ((ObjectQuery)tmp).Include("Group");

            return tmp;
        }

        public override DepartmentLoad GetOrDefault(Func<DepartmentLoad, bool> func, DepartmentLoad def = null)
        {
            return db.DepartmentLoads.FirstOrDefault(func) ?? def;
        }

        public override void Update(DepartmentLoad item)
        {
            db.DepartmentLoads.Update(item);
            db.SaveChanges();
        }

        public override void UpdateRange(DepartmentLoad[] items)
        {
            db.DepartmentLoads.UpdateRange(items);
        }

        //public override void DeleteRange(BlockNum[] items)
        //{
        //    db.RemoveRange(items)
        //}

    }
}
