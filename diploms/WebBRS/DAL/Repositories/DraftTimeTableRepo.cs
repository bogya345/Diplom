using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;



namespace WebBRS.DAL.Repositories
{
	public class DraftTimeTableRepo : IRepository<DraftTimeTable>
    {
        public DraftTimeTableRepo(MyContext context) : base(context) { }


        public override void Create(DraftTimeTable item)
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

        public override void Delete(DraftTimeTable item)
        {
            throw new NotImplementedException();
        }

        public DraftTimeTable Get(int id)
        {
            throw new NotImplementedException();
        }
        public override DraftTimeTable Get(Func<DraftTimeTable, bool> func)
        {
            return db.DraftTimeTables
                .FirstOrDefault(func);
        }

        public IEnumerable<DraftTimeTable> GetAll()
        {
            //List<TypeTimeTable> tmp = new List<TypeTimeTable>();
            //tmp = db.StudentsGroupHistories
            //    .Include(sgh => sgh.Group)
            //    .Include(sgh => sgh.Course)
            //    //.Include(sgh => sgh.Attendances)
            //    //.Include(sgh => sgh.Student)
            //    .ToList();
            return db.DraftTimeTables;

            //return db.AuthUsers;
        }
        public override IEnumerable<DraftTimeTable> GetAll(Func<DraftTimeTable, bool> func)
        {
            return db.DraftTimeTables
                 .Where(func);
        }

        public override DraftTimeTable OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(DraftTimeTable item)
        {
            throw new NotImplementedException();
        }
    }
}
