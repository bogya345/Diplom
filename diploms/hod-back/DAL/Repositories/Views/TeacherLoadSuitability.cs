using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Repositories
{
    public class TeacherLoadSuitabilityRepository : IRepository<TeacherLoadSuitability>
    {
        public TeacherLoadSuitabilityRepository(Context context) : base(context) { }

        public override IEnumerable<TeacherLoadSuitability> GetMany(Func<TeacherLoadSuitability, bool> func)
        {
            return db.TeacherLoadSuitabilities.Where(func);
        }
        public override async Task<IEnumerable<TeacherLoadSuitability>> GetManyAsync(Func<TeacherLoadSuitability, bool> func)
        {
            var tmp = db.TeacherLoadSuitabilities.ToListAsync();
            return tmp.Result.Where(func);
        }

        public IEnumerable<TeacherLoadSuitability> GetAll() { return db.TeacherLoadSuitabilities; }
        public async Task<IEnumerable<TeacherLoadSuitability>> GetAllAsync()
        {
            var tmp = db.TeacherLoadSuitabilities.ToListAsync();
            return tmp.Result;

            //IEnumerable<DepDirFac> GetData()
            //{
            //    foreach (var i in tmp)
            //        yield return i;
            //}

            //return GetData();
        }
        //public override 

        public override TeacherLoadSuitability GetOrDefault(Func<TeacherLoadSuitability, bool> func, TeacherLoadSuitability def = null)
        {
            return db.TeacherLoadSuitabilities.FirstOrDefault(func) ?? def;
        }
    }
}
