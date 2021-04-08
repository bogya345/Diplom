using hod_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Repositories
{
    public class DirRequirsRepository : IRepository<DirRequir>
    {
        public DirRequirsRepository(Context context) : base(context) { }

        public override IEnumerable<DirRequir> GetMany(Func<DirRequir, bool> func)
        {
            return db.DirRequirs.Where(func);
        }
        public IEnumerable<DirRequir> GetAll()
        {
            return db.DirRequirs;
        }

    }
}
