using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Repositories
{
    public class TeacherRatesRepository : IRepository<TeacherRate>
    {
        public TeacherRatesRepository(Context context) : base(context) { }

        public override IEnumerable<TeacherRate> GetMany(Func<TeacherRate, bool> func)
        {
            return db.TeacherRates.Where(func);
        }
        public override async Task<IEnumerable<TeacherRate>> GetManyAsync(Func<TeacherRate, bool> func)
        {
            var tmp = db.TeacherRates.ToListAsync();
            return tmp.Result.Where(func);
        }

        public IEnumerable<TeacherRate> GetAll() { return db.TeacherRates; }
        public async Task<IEnumerable<TeacherRate>> GetAllAsync()
        {
            var tmp = db.TeacherRates.ToListAsync();
            return tmp.Result;

            //IEnumerable<DepDirFac> GetData()
            //{
            //    foreach (var i in tmp)
            //        yield return i;
            //}

            //return GetData();
        }
        //public override 

        public override TeacherRate GetOrDefault(Func<TeacherRate, bool> func, TeacherRate def = null)
        {
            return db.TeacherRates.FirstOrDefault(func) ?? def;
        }
    }
}
