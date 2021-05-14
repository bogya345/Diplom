using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Repositories
{
    public class TeacherSuitabilityReporitory : IRepository<TeacherSuitability>
    {
        public TeacherSuitabilityReporitory(Context context) : base(context) { }

        public override IEnumerable<TeacherSuitability> GetMany(Func<TeacherSuitability, bool> func)
        {
            try
            {
                return db.TeacherSuitabilities.Where(func);
            }
            catch (InvalidOperationException ex)
            {
                return new Context().TeacherSuitabilities.Where(func);
            }
        }
        public IEnumerable<TeacherSuitability> GetAll() { return db.TeacherSuitabilities; }
        public async Task<IEnumerable<TeacherSuitability>> GetAllAsync()
        {
            try
            {
                var tmp = db.TeacherSuitabilities.ToListAsync();
                return tmp.Result;
            }
            catch (InvalidOperationException ex)
            {
                var tmp = new Context().TeacherSuitabilities.ToListAsync();
                return tmp.Result;
            }

            //IEnumerable<DepDirFac> GetData()
            //{
            //    foreach (var i in tmp)
            //        yield return i;
            //}

            //return GetData();
        }
        //public override 

        public override TeacherSuitability GetOrDefault(Func<TeacherSuitability, bool> func, TeacherSuitability def = null)
        {
            try
            {
                return db.TeacherSuitabilities.FirstOrDefault(func) ?? def;
            }
            catch (InvalidOperationException ex)
            {
                return new Context().TeacherSuitabilities.FirstOrDefault(func) ?? def;
            }
        }
    }
}
