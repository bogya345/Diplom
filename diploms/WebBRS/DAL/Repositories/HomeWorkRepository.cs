using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;
namespace WebBRS.DAL.Repositories
{
	public class HomeWorkRepository:IRepository<ClassWork>
    {
        public HomeWorkRepository(MyContext context) : base(context) { }


        public override void Create(ClassWork item)
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

        public override void Delete(ClassWork item)
        {
            throw new NotImplementedException();
        }

        public ClassWork Get(int id)
        {
            throw new NotImplementedException();
        }
        public override ClassWork Get(Func<ClassWork, bool> func)
        {
            return db.ClassWorks.FirstOrDefault(func);
        }

        public IEnumerable<ClassWork> GetAll()
        {
            //throw new NotImplementedException();
            IEnumerable<ClassWork> tmp = db.ClassWorks;

            return db.ClassWorks.ToList();

        }
        public override IEnumerable<ClassWork> GetAll(Func<ClassWork, bool> func)
        {
            return db.ClassWorks.Where(func);
        }

        public override ClassWork OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(ClassWork item)
        {
            throw new NotImplementedException();
        }
    }
}
