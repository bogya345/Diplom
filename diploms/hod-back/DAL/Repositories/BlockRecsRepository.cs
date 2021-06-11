using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;

using hod_back.Extentions;
using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Repositories
{
    public class BlockRecsRepository : IRepository<BlockRec>
    {
        public BlockRecsRepository(Context context) : base(context) { }


        public override void Create(BlockRec item)
        {
            db.BlockRecs.Add(item);
            db.SaveChanges();

            List<Group> groups = db.Groups.Where(x => x.DirId == db.Directions.FirstOrDefault(y => y.AcPlId == item.AcPlId).DirId).ToList();
            // оно будет высчитываться для каждой записи - надо бы придумать как это дело оптимизировать

            var attRecs = item.TransformToAttAcPlan(groups);
            db.AttachedAcPlans.AddRange(attRecs);
            db.SaveChanges();
        }
        public override void CreateAsync(BlockRec item)
        {
            List<AttachedAcPlan> listToCreate = new List<AttachedAcPlan>();
            List<Group> groups;

        mark0:
            try
            {
                db.BlockRecs.Add(item);
                db.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                Task.Delay(1000);
                goto mark0;
            }

        mark:
            try
            {

            mark1:
                try
                {
                    groups = db.Groups.Where(x => x.DirId == db.Directions.FirstOrDefault(y => y.AcPlId == item.AcPlId).DirId).ToList();
                }
                catch (InvalidOperationException ex)
                {
                    Task.Delay(1000);
                    goto mark1;
                }

                //fdb.AttachedAcPlans.AddRange(attRecs);
                //fdb.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                Task.Delay(1000);
                goto mark;
            }

            var attRecs = item.TransformToAttAcPlan(groups);

            foreach (var i in attRecs)
            {
                listToCreate.Add(i);
            }

        mark3:
            try
            {
                db.AttachedAcPlans.AddRange(listToCreate);
            }
            catch (InvalidOperationException ex)
            {
                Task.Delay(1000);
                goto mark3;
            }

        mark4:
            try
            {
                db.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                Task.Delay(1000);
                goto mark4;
            }
        }

        public override void CreateRange(BlockRec[] items)
        {
            //db.AddRange(items);
            foreach (var i in items)
            {
                Create(i);
            }
            db.SaveChanges();
        }

        public override void CreateRangeAsync(BlockRec[] items)
        {

            foreach (var i in items)
            {
                CreateAsync(i);
            }

            //mark:
            //    try
            //    {
            //        db.SaveChangesAsync();
            //    }
            //    catch (InvalidOperationException ex)
            //    {
            //        Task.Delay(1000);
            //        goto mark;
            //    }
        }

        public IEnumerable<BlockRec> GetAll()
        {
            return db.BlockRecs;
        }

        public override IEnumerable<BlockRec> GetMany(Func<BlockRec, bool> func)
        {
            return db.BlockRecs.Where(func);
        }
        public async override Task<IEnumerable<BlockRec>> GetManyAsync(Func<BlockRec, bool> func)
        {
        mark:
            try
            {
                var res = db.BlockRecs.Where(func).ToList();
                return res;
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }

        public override bool OnExist(Func<BlockRec, bool> func)
        {
            try
            {
                return db.BlockRecs.Where(func).Any();
            }
            catch (InvalidOperationException ex)
            {
                return new Context().BlockRecs.Where(func).Any();
            }
        }

        public override IEnumerable<BlockRec> GetManyWithInclude(Func<BlockRec, bool> func)
        {
            return db.BlockRecs
                .Include(x => x.BlockNum)
                .Where(func);
        }

        public async override Task<IEnumerable<BlockRec>> GetManyWithIncludeAsync(Func<BlockRec, bool> func)
        {
        mark:
            try
            {
                return db.BlockRecs
                    .Include(x => x.Sub).ThenInclude(y => y.AcPlDep).ThenInclude(z => z.Dep)
                    .Include(x => x.AttachedAcPlans).ThenInclude(z => z.FshId1Navigation).ThenInclude(k => k.Fs).ThenInclude(p => p.Emp)
                    .Include(x => x.AttachedAcPlans).ThenInclude(z => z.FshId2Navigation).ThenInclude(k => k.Fs).ThenInclude(p => p.Emp)
                    .Include(X => X.AttachedAcPlans).ThenInclude(y => y.SubT)
                    .Where(func)
                    .ToList();
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto mark;
            }
        }

        public override void UpdateRange(BlockRec[] items)
        {
            db.UpdateRange(items);
            db.SaveChanges();
        }

        public override void DeleteRange(BlockRec[] items)
        {
            db.BlockRecs.RemoveRange(items);
        }

    }
}
