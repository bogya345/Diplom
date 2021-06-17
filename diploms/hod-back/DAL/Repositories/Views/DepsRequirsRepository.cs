using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using hod_back.Models;

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

        public new bool UpdateRangeAsync(ChangesFgosModel model)
        {
            List<DirFgo> tmp = new List<DirFgo>();
        mark:
            try
            {
                tmp = this.db.DirFgos
                    .Include(x => x.Fgos)
                    .Where(x => x.DirId == model.DirId).ToList();
            }
            catch (InvalidOperationException ex)
            {
                //await Task.Delay(1000);
                goto mark;
            }

            // 4.4.3 - 7.2.2
            tmp.First(x => x.Fgos.FgosNum.Contains("7.2.2")).SettedValue = (float)Convert.ToDouble(model.Fgos443);
            // 4.4.4 - 7.2.4
            tmp.First(x => x.Fgos.FgosNum.Contains("7.2.4")).SettedValue = (float)Convert.ToDouble(model.Fgos444);
            // 4.4.5 - 7.2.3
            tmp.First(x => x.Fgos.FgosNum.Contains("7.2.3")).SettedValue = (float)Convert.ToDouble(model.Fgos445);

            foreach(var i in tmp)
            {
                this.db.DirFgos.Update(i);
            }
            this.db.SaveChanges();
            //this.db.Update(tmp);
            return true;
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
