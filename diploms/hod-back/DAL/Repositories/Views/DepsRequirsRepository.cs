using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace hod_back.DAL.Repositories
{
    public class DirRequirsRepository : IRepository<DirRequir>
    {
        public DirRequirsRepository(Context context) : base(context) { }

        public override IEnumerable<DirRequir> GetMany(Func<DirRequir, bool> func)
        {
            try
            {
                return db.DirRequirs.Where(func);
            }
            catch (InvalidOperationException ex)
            {
                return new Context().DirRequirs.Where(func);
            }
        }
        public async override Task<IEnumerable<DirRequir>> GetManyAsync(Func<DirRequir, bool> func)
        {
        mark:
            try
            {
                return db.DirRequirs.Where(func).ToList();
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }
        public async Task<IEnumerable<DirRequir>> GetManyAsync(int? dirId)
        {
            if (dirId == null) { return null; }
        mark:
            try
            {
                var edBr = db.EducBranches.Include(x => x.Directions).FirstOrDefault(x => x.Directions.Any(x => x.DirId == dirId));
                var tmp = edBr.Directions.ToList();
                var res = db.DirRequirs.Where(x => tmp.Any(y => x.DirId == y.DirId)).ToList();
                return res;
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }
        public override DirRequir GetOrDefault(Func<DirRequir, bool> func, DirRequir def = null)
        {
            return db.DirRequirs.FirstOrDefault(func) ?? def;
        }
        public async override Task<DirRequir> GetOrDefaultAsync(Func<DirRequir, bool> func, DirRequir def = null)
        {
        mark:
            try
            {
                return db.DirRequirs.FirstOrDefault(func) ?? def;
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }

        //public override async Task<DirRequir> GetOrDefaultAsync(Func<DirRequir, bool> func, DirRequir def = null)
        //{
        //    return db.DirRequirs.FirstOrDefaultAsync(func, CancellationToken.None);
        //}
        public override IEnumerable<DirRequir> GetAll()
        {
            return db.DirRequirs;
        }

    }
}
