using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class TypeAttedancesRepo : IRepository<TypeAttedance>
    {
        public TypeAttedancesRepo(MyContext context) : base(context) { }


        public override void Create(TypeAttedance item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TypeAttedance item)
        {
            throw new NotImplementedException();
        }

        public Attendance Get(int id)
        {
            throw new NotImplementedException();
        }
        public override TypeAttedance Get(Func<TypeAttedance, bool> func)
        {
            return db.TypeAttedances.FirstOrDefault(func);
        }

        public IEnumerable<TypeAttedance> GetAll()
        {
            return db.TypeAttedances;
            //return db.AuthUsers;
        }
        public override IEnumerable<TypeAttedance> GetAll(Func<TypeAttedance, bool> func)
        {
            return db.TypeAttedances.Where(func);
        }

        public override TypeAttedance OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(TypeAttedance item)
        {
            throw new NotImplementedException();
        }
    }
}