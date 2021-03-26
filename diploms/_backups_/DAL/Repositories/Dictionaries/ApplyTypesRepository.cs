using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL;
using hod_back.DAL.Models.Dictionaries;

using hod_back.DAL.Contexts;

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

        public override WorkType OnExist(string name)
        {
            throw new NotImplementedException();
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

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(WorkType item)
        {
            throw new NotImplementedException();
        }

    }
}
