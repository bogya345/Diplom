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
            catch(InvalidOperationException ex)
            {
                return new Context().DirRequirs.Where(func);
            }
        }
        public override DirRequir GetOrDefault(Func<DirRequir, bool> func, DirRequir def = null)
        {
            return db.DirRequirs.FirstOrDefault(func) ?? def;
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
