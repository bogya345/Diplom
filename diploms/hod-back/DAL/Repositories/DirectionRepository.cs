using AutoMapper;
using hod_back.Model;
using hod_back.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return db.Directions.FirstOrDefault(func) ?? def;
        }

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
