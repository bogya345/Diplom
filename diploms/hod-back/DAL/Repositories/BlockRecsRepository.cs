using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class AcPlanRepository : IRepository<AcPlan>
    {
        public AcPlanRepository(Context context) : base(context) { }


        public override AcPlan CreateWithReturn(AcPlan item) { db.AcPlans.Add(item); db.SaveChanges(); return item; }
        public override void CreateRange(AcPlan[] items) { db.AddRange(items); }

        public override AcPlan GetOrDefault(Func<AcPlan, bool> func, AcPlan def = null)
        {
            return db.AcPlans.FirstOrDefault(func) ?? def;
        }

        public IEnumerable<AcPlan> GetAll()
        {
            return db.AcPlans;
        }

        public override IEnumerable<AcPlan> GetMany(Func<AcPlan, bool> func)
        {
            return db.AcPlans.Where(func);
        }

        public override void Update(AcPlan item)
        {
            db.AcPlans.Update(item);
            db.SaveChanges();
        }
        public override void UpdateRande(AcPlan[] items)
        {
            db.UpdateRange(items);
        }

    }
}
