using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;


namespace WebBRS.DAL.Repositories
{
	public class HomeWorkStudentsRepo: IRepository<DoClassWorkAttend>
	{
        public HomeWorkStudentsRepo(MyContext context) : base(context) { }


        public override void Create(DoClassWorkAttend item)
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

        public override void Delete(DoClassWorkAttend item)
        {
            throw new NotImplementedException();
        }

        public HomeWorkStudentsRepo Get(int id)
        {
            throw new NotImplementedException();
        }
        public override DoClassWorkAttend Get(Func<DoClassWorkAttend, bool> func)
        {
            return db.DoClassWorkAttends.FirstOrDefault(func);
        } 


        public IEnumerable<DoClassWorkAttend> GetAll()
        {
            //throw new NotImplementedException();
            IEnumerable<DoClassWorkAttend> tmp = db.DoClassWorkAttends;

            return db.DoClassWorkAttends.ToList();

        }
        public override IEnumerable<DoClassWorkAttend> GetAll(Func<DoClassWorkAttend, bool> func)
        {
            return db.DoClassWorkAttends.Where(func);
        }

        public override DoClassWorkAttend OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(DoClassWorkAttend item)
        {
            throw new NotImplementedException();
        }
    }
}
