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
            mark:
            try
            {
                var tmp = db.TeacherRates.Where(func).ToList();
                return tmp;
            }
            catch(InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
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


        public override async Task<TeacherRate> GetOrDefaultAsync(Func<TeacherRate, bool> func, TeacherRate def = null)
        {
        mark:
            try
            {
                return db.TeacherRates.FirstOrDefault(func);
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }
    }
}
