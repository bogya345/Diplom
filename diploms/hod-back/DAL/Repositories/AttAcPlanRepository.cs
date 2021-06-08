using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class AttAcPlanRepository : IRepository<AttachedAcPlan>
    {
        public AttAcPlanRepository(Context context) : base(context) { }


        public override void Create(AttachedAcPlan item) { db.AttachedAcPlans.Add(item); }
        public override AttachedAcPlan CreateWithReturn(AttachedAcPlan item)
        {
            db.AttachedAcPlans.Add(item);
            db.SaveChanges();
            return item;
        }
        public override void CreateRange(AttachedAcPlan[] items) { db.AddRange(items); db.SaveChanges(); }

        public override IEnumerable<AttachedAcPlan> GetAll()
        {
            return db.AttachedAcPlans;
        }

        public override IEnumerable<AttachedAcPlan> GetMany(Func<AttachedAcPlan, bool> func)
        {
            return db.AttachedAcPlans.Where(func);
        }

        public override async Task<IEnumerable<AttachedAcPlan>> GetManyAsync(Func<AttachedAcPlan, bool> func)
        {
        mark:
            try
            {
                var tmp = db.AttachedAcPlans.ToList();
                return tmp.Where(func);
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }

        public override IEnumerable<AttachedAcPlan> GetManyWithInclude(Func<AttachedAcPlan, bool> func)
        {
            //var tmp = db.AttachedAcPlans
            //    //.Include(x => x.Group)
            //    //.Include(x => x.BlockRec)
            //    //.Include(x => x.BlockRec.BlockNum)
            //    //.Include(x => x.BlockRec.Sub)
            //    .Where(func)
            //    ;

            var tmp = from attAcPl in db.AttachedAcPlans
                      where attAcPl.GroupId == 9919
                      //orderby attAcPl.
                      select attAcPl
                      ;

            //var questionsWithInclude = ((ObjectQuery)tmp).Include("Group");

            return tmp;
        }

        public override AttachedAcPlan GetOrDefault(Func<AttachedAcPlan, bool> func, AttachedAcPlan def = null)
        {
            return db.AttachedAcPlans.FirstOrDefault(func) ?? def;
        }
        public async override Task<AttachedAcPlan> GetOrDefaultAsync(Func<AttachedAcPlan, bool> func, AttachedAcPlan def = null)
        {
            mark:
            try
            {
                return db.AttachedAcPlans.FirstOrDefault(func) ?? def;
            }
            catch(InvalidProgramException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }

        public override void Update(AttachedAcPlan item)
        {
            db.AttachedAcPlans.Update(item);
            db.SaveChanges();
        }

        public override void UpdateRange(AttachedAcPlan[] items)
        {
            db.AttachedAcPlans.UpdateRange(items);
        }

        //public override void DeleteRange(BlockNum[] items)
        //{
        //    db.RemoveRange(items)
        //}

    }
}
