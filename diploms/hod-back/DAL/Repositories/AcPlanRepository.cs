using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class BlockNumRepository : IRepository<BlockNum>
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

        public IEnumerable<BlockRec> GetAll()
        {
            return db.BlockRecs;
        }

        public override IEnumerable<BlockNum> GetMany(Func<BlockNum, bool> func)
        {
            return db.BlockNums.Where(func);
        }

        public override void UpdateRande(BlockNum[] items)
        {
            db.UpdateRange(items);
        }

    }
}
