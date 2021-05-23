using AutoMapper;
using hod_back.Model;
using hod_back.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Repositories
{
    public class DirectionRepository : IRepository<Direction>
    {
        private IMapper _mapper;
        public DirectionRepository(Context context) : base(context)
        {
            this._mapper = new Mapper(new MapperConfiguration(c =>
            {
                c.AddProfile(new DirectionsProfile());
            }));
        }

        public override Direction GetOrDefault(Func<Direction, bool> func, Direction def = null)
        {
            try
            {
                return db.Directions.FirstOrDefault(func) ?? def;
            }
            catch (InvalidOperationException ex)
            {
                return new Context().Directions.FirstOrDefault(func) ?? def;
            }
        }
        public override async Task<Direction> GetOrDefaultAsync(Func<Direction, bool> func, Direction def = null)
        {
        mark:
            try
            {
                var res = await db.Directions.ToListAsync();
                return res.FirstOrDefault(func) ?? def;
            }
            catch (InvalidOperationException ex)
            {
                Task.Delay(1000);
                goto mark;
            }
        }

        public override Direction GetOrDefaultWithInclude(Func<Direction, bool> func, Direction def = null)
        {
            return db.Directions
                .Include(x => x.EForm)
                .Include(x => x.EBr)
                .Include(x => x.AcPl)
                .FirstOrDefault(func);
        }
        //public override Task<Direction> GetOrDefaultWithIncludeAsync(Func<Direction, bool> func, Direction def = null)
        //{
        //    //Expression andExpr = Expression.Convert(Expression.Lambda<Func<Direction, bool>>, typeof(Func<Direction, bool>), func.Method);

        //    return db.Directions
        //        .Include(x => x.EForm)
        //        .Include(x => x.EBr)
        //        //.FirstOrDefaultAsync(Expression.Lambda<Func<Direction, bool>>(func), new System.Threading.CancellationToken());
        //        //.FirstOrDefaultAsync(Expression.Lambda(, new System.Threading.CancellationToken());
        //        .FirstOrDefaultAsync(func);
        //}
        public override IEnumerable<Direction> GetMany(Func<Direction, bool> func)
        {
            return db.Directions.Where(func);
        }

        public override void Update(Direction item)
        {
            var i = db.Directions.FirstOrDefault(x => x.DirId == item.DirId);
            _mapper.Map(item, i);
            db.SaveChanges();
        }
    }
}
