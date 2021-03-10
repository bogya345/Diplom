using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;

using hod_back.DAL.Contexts;

namespace hod_back.DAL.Repositories
{
    public class SubjectsRepository : IRepository<Subjects>
    {
        public SubjectsRepository(Context context) : base(context) { }


        public override void Create(Subjects item)
        {
            db.Subjects.Add(item);
        }

        public override void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Subjects item)
        {
            throw new NotImplementedException();
        }

        public Subjects Get(int id)
        {
            throw new NotImplementedException();
        }
        public override Subjects Get(Func<Subjects, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subjects> GetAll()
        {
            if (DAL_Settings.localAccess)
            {
                return LocalStorage.subs;
            }
            return db.Subjects;
        }
        public override IEnumerable<Subjects> GetAll(Func<Subjects, bool> func)
        {
            if (DAL_Settings.localAccess)
            {
                return LocalStorage.subs.Where(func);
            }
            return db.Subjects.Where(func);
        }

        public override Subjects OnExist(string name)
        {
            return db.Subjects.Where(x => x.NAME == name).FirstOrDefault();
        }

        public override void Update(Subjects item)
        {
            throw new NotImplementedException();
        }
    }
}
