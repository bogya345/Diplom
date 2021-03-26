using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;

using hod_back.DAL.Contexts;

namespace hod_back.DAL.Repositories
{
    public class BlockRecsRepository : IRepository<BlockRecs>
    {
        public BlockRecsRepository(Context context) : base(context) { }


        public override void Create(BlockRecs item)
        {
            db.BlockRecs.Add(item);
        }

        public IEnumerable<BlockRecs> GetAll()
        {
            if (DAL_Settings.localAccess)
            {
                return LocalStorage.blockrecs;
            }
            return db.BlockRecs;
        }

        public override IEnumerable<BlockRecs> GetMany(Func<BlockRecs, bool> func)
        {
            if (DAL_Settings.localAccess)
            {
                return LocalStorage.blockrecs.Where(func);
            }
            return db.BlockRecs.Where(func);
        }

    }
}
