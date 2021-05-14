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
            var fdb = new Context();

            fdb.BlockRecs.Add(item);
            fdb.SaveChanges();

            List<Group> groups;
            try
            {
                groups = fdb.Groups.Where(x => x.DirId == fdb.Directions.FirstOrDefault(y => y.AcPlId == item.AcPlId).DirId).ToList();
            }
            catch (InvalidOperationException ex)
            {
                //groups = fdb.Groups.Where(x => x.DirId == fdb.Directions.FirstOrDefault(y => y.AcPlId == item.AcPlId).DirId).ToList();
                throw new Exception(); // не, ну это пипяу если до этого дошло
            }

            var attRecs = item.TransformToAttAcPlan(groups);
            fdb.AttachedAcPlans.AddRange(attRecs);
            fdb.SaveChanges();
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
            db.SaveChangesAsync();
        }

        public IEnumerable<BlockRec> GetAll()
        {
            return db.BlockRecs;
        }

        public override IEnumerable<BlockRec> GetMany(Func<BlockRec, bool> func)
        {
            try
            {
                return db.BlockRecs.Where(func);
            }
            catch(InvalidOperationException ex)
            {
                return new Context().BlockRecs.Where(func);
            }
        }
        public override bool OnExist(Func<BlockRec, bool> func)
        {
            try
            {
                return db.BlockRecs.Where(func).Any();
            }
            catch(InvalidOperationException ex)
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
