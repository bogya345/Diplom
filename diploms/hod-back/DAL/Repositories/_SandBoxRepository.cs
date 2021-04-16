using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class SandBoxRepository
    {
        private Context db;

        public SandBoxRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<AttachedAcPlan> GetManyWithInclude(Func<AttachedAcPlan, bool> func)
        {
            //var tmp = from attAcPl in db.AttachedAcPlans
            //          where attAcPl.GroupId == 9919
            //          //orderby attAcPl.
            //          select attAcPl
            //          ;

            var tmp = db.AttachedAcPlans
                .Include(x => x.Group)
                //.ThenInclude()
                .Include(x => x.SubT)
                .Include(x => x.BlockRec)
                .ThenInclude(y => y.AcPl)
                .Where(func)
                .ToList();

            if (tmp[0].SubTId == 1) { tmp[0].HourValue = tmp[0].BlockRec.Les; }

            return tmp;
        }
    }
}
