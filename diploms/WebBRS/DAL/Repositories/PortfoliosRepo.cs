using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class PortfoliosRepo : IRepository<Portfolio>
    {
        public PortfoliosRepo(MyContext context) : base(context) { }


        public override void Create(Portfolio item)
        {
            db.Portfolios.Add(item);
        }

        public override void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Portfolio item)
        {
             db.Portfolios.Remove(item) ;
        }

        public Portfolio Get(int id)
        {
            return db.Portfolios.Include(p => p.Curator)
                .Include(p => p.Person).FirstOrDefault(p => p.IdPortfolio == id);
        }
        public override Portfolio Get(Func<Portfolio, bool> func)
        {
            return db.Portfolios.Include(p => p.Curator)
                .Include(p => p.Person).FirstOrDefault(func);
        }

        public IEnumerable<Portfolio> GetAll()
        {
            //throw new NotImplementedException();
            //IEnumerable<Person> tmp = db.Persons;

            return db.Portfolios.Include(p => p.Curator)
                .Include(p => p.Person).ToList();

        }
        public override IEnumerable<Portfolio> GetAll(Func<Portfolio, bool> func)
        {
            return db.Portfolios
                .Include(p=>p.Curator)
                .Include(p=>p.Person)
                .Where(func);
        }

        public override Portfolio OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Portfolio item)
        {
            throw new NotImplementedException();
        }
    }
}
