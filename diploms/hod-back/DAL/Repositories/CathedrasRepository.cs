using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class DepartmentsRepository : IRepository<Department>
    {
        public DepartmentsRepository(Context context) : base(context) { }

        public override Department GetOrDefault(Func<Department, bool> func, Department def = null)
        {
            return db.Departments.FirstOrDefault(func) ?? def;
        }

        public override IEnumerable<Department> GetMany(Func<Department, bool> func)
        {
            return db.Departments.Where(func);
        }

    }
}
