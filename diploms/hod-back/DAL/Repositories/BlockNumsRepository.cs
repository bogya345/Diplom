using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;
using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Repositories
{
    public class BlockNumRepository : IRepository<BlockNum>//, IOwnDictionary
    {
        public BlockNumRepository(Context context) : base(context) { }


        public override void Create(BlockNum item) { db.BlockNums.Add(item); }
        public override BlockNum CreateWithReturn(BlockNum item)
        {
            db.BlockNums.Add(item);
            db.SaveChanges();
            return item;
        }
        public override void CreateRange(BlockNum[] items) { db.AddRange(items); db.SaveChanges(); }

        public override IEnumerable<BlockNum> GetAll()
        {
            return db.BlockNums;
        }

        public override IEnumerable<BlockNum> GetMany(Func<BlockNum, bool> func)
        {
            return db.BlockNums.Where(func);
        }

        public override IEnumerable<BlockNum> GetManyWithInclude(Func<BlockNum, bool> func)
        {
            return db.BlockNums

                .Include(x => x.BlockRecs)
                .ThenInclude(y => y.Sub)
                .ThenInclude(z => z.AcPlDep)
                .ThenInclude(k => k.Dep)
                //.ThenInclude(p => p.)

                .Include(x => x.BlockRecs)
                .ThenInclude(y => y.AttachedAcPlans)
                .ThenInclude(z => z.SubT)

                .Include(x => x.BlockRecs)
                .ThenInclude(y => y.AttachedAcPlans)
                .ThenInclude(z => z.Fsh)
                .ThenInclude(k => k.Fs)
                .ThenInclude(p => p.Emp)

                //.Include(x => x.BlockRecs)
                //.ThenInclude(y => y.AcPl)
                //.ThenInclude(z => z.Directions)
                //.ThenInclude(k => k.Dep)

                .Where(func);
        }
        public override async Task<IEnumerable<BlockNum>> GetManyWithIncludeAsync(Func<BlockNum, bool> func)
        {
            return db.BlockNums

                .Include(x => x.BlockRecs)
                .ThenInclude(y => y.Sub)
                .ThenInclude(z => z.AcPlDep)
                .ThenInclude(k => k.Dep)
                //.ThenInclude(p => p.)

                .Include(x => x.BlockRecs)
                .ThenInclude(y => y.AttachedAcPlans)
                .ThenInclude(z => z.SubT)

                .Include(x => x.BlockRecs)
                .ThenInclude(y => y.AttachedAcPlans)
                .ThenInclude(z => z.Fsh)
                .ThenInclude(k => k.Fs)
                .ThenInclude(p => p.Emp)

                //.Include(x => x.BlockRecs)
                //.ThenInclude(y => y.AcPl)
                //.ThenInclude(z => z.Directions)
                //.ThenInclude(k => k.Dep)

                .Where(func);
        }

        //public IEnu

        //public IEnumerable<BlockNum> GetManySpecify()
        //{
        //    return 
        //}

        public override void UpdateRange(BlockNum[] items)
        {
            db.UpdateRange(items);
        }

        //public override void DeleteRange(BlockNum[] items)
        //{
        //    db.RemoveRange(items)
        //}

    }

    public static class BlockNumRepositoryExtention
    {
        //public static IEnumerable<BlockNum> GetMany_Specify(this BlockNumRepository item, Func<BlockNum, bool> func, string includeString)
        //{
        //    return item.db.BlockNums.Include(includeString).Where(func);
        //}
    }
}
