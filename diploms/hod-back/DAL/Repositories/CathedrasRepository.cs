using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;

using hod_back.DAL.Contexts;

namespace hod_back.DAL.Repositories
{
    public class DepartmentsRepository : IRepository<Departments>
    {
        public DepartmentsRepository(Context context) : base(context) { }


        public override void Create(Departments item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Departments item)
        {
            throw new NotImplementedException();
        }

        public Departments Get(int id)
        {
            throw new NotImplementedException();
        }
        public override Departments Get(Func<Departments, bool> func)
        {
            if (DAL_Settings.localAccess)
            {
                return LocalStorage.deps.FirstOrDefault(func);
            }
            return db.Departments.FirstOrDefault(func);
        }

        public override IEnumerable<Departments> GetAll(Func<Departments, bool> func)
        {
            if (DAL_Settings.localAccess)
            {
                return LocalStorage.deps.Where(func);
            }
            return db.Departments.Where(func);
        }

        public override Departments OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Departments item)
        {
            throw new NotImplementedException();
        }
    }
}
