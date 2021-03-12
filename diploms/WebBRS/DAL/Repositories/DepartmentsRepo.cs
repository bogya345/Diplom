using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class DepartmentsRepo : IRepository<Department>
    {
        public DepartmentsRepo(MyContext context) : base(context) { }


        public override void Create(Department item)
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

        public override void Delete(Department item)
        {
            throw new NotImplementedException();
        }

        public Department Get(int id)
        {
            throw new NotImplementedException();
        }
        public override Department Get(Func<Department, bool> func)
        {
            return db.Departments.FirstOrDefault(func);
        }

        public IEnumerable<Department> GetAll()
        {
            //throw new NotImplementedException();
            IEnumerable<Department> tmp = db.Departments;

            return db.Departments.ToList();

        }
        public override IEnumerable<Department> GetAll(Func<Department, bool> func)
        {
            return db.Departments.Where(func);
        }

        public override Department OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Department item)
        {
            throw new NotImplementedException();
        }
    }
}
