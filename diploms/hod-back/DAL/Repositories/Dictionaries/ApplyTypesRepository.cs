using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class WorkTypesRepository : IRepository<WorkType>
    {
        public WorkTypesRepository(Context context) : base(context) { }


        public override IEnumerable<WorkType> GetMany(Func<WorkType, bool> func)
        {
            return db.WorkTypes;
        }

        public WorkType Get(int id)
        {
            return db.WorkTypes.Find(id);
        }
        public override WorkType Get(Func<WorkType, bool> func)
        {
            return db.WorkTypes.FirstOrDefault(func);
        }

        public override void Create(WorkType item)
        {
            db.WorkTypes.Add(item);
        }

        public override void Update(WorkType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public override void Delete(int itemId)
        {
            WorkType book = db.WorkTypes.Find(itemId);
            if (book != null)
                db.WorkTypes.Remove(book);
        }

    }
}
