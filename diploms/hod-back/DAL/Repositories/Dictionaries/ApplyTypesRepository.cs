using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL;
using hod_back.DAL.Models.Dictionaries;

using hod_back.DAL.Contexts;

namespace hod_back.DAL.Repositories
{
    public class ApplyTypesRepository : IRepository<ApplyTypes>
    {
        public ApplyTypesRepository(Context context) : base(context) { }


        public override IEnumerable<ApplyTypes> GetMany(Func<ApplyTypes, bool> func)
        {
            return db.ApplyTypes;
        }

        public ApplyTypes Get(int id)
        {
            return db.ApplyTypes.Find(id);
        }
        public override ApplyTypes Get(Func<ApplyTypes, bool> func)
        {
            return db.ApplyTypes.FirstOrDefault(func);
        }

        public override ApplyTypes OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Create(ApplyTypes item)
        {
            db.ApplyTypes.Add(item);
        }

        public override void Update(ApplyTypes item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public override void Delete(int itemId)
        {
            ApplyTypes book = db.ApplyTypes.Find(itemId);
            if (book != null)
                db.ApplyTypes.Remove(book);
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(ApplyTypes item)
        {
            throw new NotImplementedException();
        }

    }
}
