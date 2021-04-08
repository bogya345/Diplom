using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class BlockRecsRepository : IRepository<BlockRec>
    {
        public BlockRecsRepository(Context context) : base(context) { }


        public override void Create(BlockRec item) { db.BlockRecs.Add(item); }
        public override void CreateRange(BlockRec[] items) { db.AddRange(items); }

        public IEnumerable<BlockRec> GetAll()
        {
            return db.BlockRecs;
        }

        public override IEnumerable<BlockRec> GetMany(Func<BlockRec, bool> func)
        {
            return db.BlockRecs.Where(func);
        }

        public override void UpdateRande(BlockRec[] items)
        {
            db.UpdateRange(items);
        }

    }
}
