using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;
namespace WebBRS.DAL.Repositories
{
	public class DraftTypesRepo : IRepository<TypeTimeTable>
    {
        public DraftTypesRepo(MyContext context) : base(context) { }


        public override void Create(TypeTimeTable item)
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

        public override void Delete(TypeTimeTable item)
        {
            throw new NotImplementedException();
        }

        public TypeTimeTable Get(int id)
        {
            throw new NotImplementedException();
        }
        public override TypeTimeTable Get(Func<TypeTimeTable, bool> func)
        {
            return db.TypeTimeTable
                .FirstOrDefault(func);
        }

        public IEnumerable<TypeTimeTable> GetAll()
        {
            //List<TypeTimeTable> tmp = new List<TypeTimeTable>();
            //tmp = db.StudentsGroupHistories
            //    .Include(sgh => sgh.Group)
            //    .Include(sgh => sgh.Course)
            //    //.Include(sgh => sgh.Attendances)
            //    //.Include(sgh => sgh.Student)
            //    .ToList();
            return db.TypeTimeTable;
                                
            //return db.AuthUsers;
        }
        public override IEnumerable<TypeTimeTable> GetAll(Func<TypeTimeTable, bool> func)
        {
            return db.TypeTimeTable
                 .Where(func);
        }

        public override TypeTimeTable OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(TypeTimeTable item)
        {
            throw new NotImplementedException();
        }
    }
}
