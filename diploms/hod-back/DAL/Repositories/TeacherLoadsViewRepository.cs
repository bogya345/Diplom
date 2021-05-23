using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class TeacherLoadsViewRepository : IRepository<TeacherLoadsView>
    {
        public TeacherLoadsViewRepository(Context context) : base(context) { }


        public override IEnumerable<TeacherLoadsView> GetAll()
        {
            return db.TeacherLoadsViews;
        }
        public override async Task<IEnumerable<TeacherLoadsView>> GetAllAsync()
        {
        mark:
            try
            {
                var tmp = db.TeacherLoadsViews;
                return tmp;
            }
            catch (InvalidOperationException ex)
            {
                Task.Delay(1000);
                goto mark;
            }
        }

        public override IEnumerable<TeacherLoadsView> GetMany(Func<TeacherLoadsView, bool> func)
        {
            try
            {
                return db.TeacherLoadsViews.Where(func);
            }
            catch (InvalidOperationException ex)
            {
                return new Context().TeacherLoadsViews.Where(func);
            }
        }
        public override async Task<IEnumerable<TeacherLoadsView>> GetManyAsync(Func<TeacherLoadsView, bool> func)
        {
        mark:
            try
            {
                var list = await db.TeacherLoadsViews.ToListAsync();
                return list.Where(func).ToList();
            }
            catch (InvalidOperationException ex)
            {
                Task.Delay(1000);
                goto mark;
            }
        }

        public override IEnumerable<TeacherLoadsView> GetManyWithInclude(Func<TeacherLoadsView, bool> func)
        {
            return db.TeacherLoadsViews
                //.Include(x => x.)
                //.ThenInclude(y => y.)
                //.Include(x => x.Dep)
                .Where(func);
        }

        public override bool OnExist(Func<TeacherLoadsView, bool> func)
        {
            try
            {
                return db.TeacherLoadsViews.Where(func).Any();
            }
            catch (InvalidOperationException ex)
            {
                return new Context().TeacherLoadsViews.Where(func).Any();
            }
        }

    }
}
