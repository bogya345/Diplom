using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

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

        public override async Task<Department> GetOrDefaultAsync(Func<Department, bool> func, Department def = null)
        {
            mark:
            try
            {
                return db.Departments.FirstOrDefault(func) ?? def;
            }
            catch(InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }

        //public override Department GetOrDefaultWithIncliude(Func<Department, bool> func, Department def = null)
        //{
        //    return db.Departments
        //}

        public override IEnumerable<Department> GetAll()
        {
            return db.Departments;
        }

        public override IEnumerable<Department> GetMany(Func<Department, bool> func)
        {
            return db.Departments.Where(func);
        }
        public override async Task<IEnumerable<Department>> GetManyAsync(Func<Department, bool> func)
        {
        mark:
            try
            {
                var tmp = db.Departments.Where(func);
                return tmp;
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }

    }
}
