using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class CuratorsRepo : IRepository<Curator>
	{
		public CuratorsRepo(MyContext context) : base(context) { }


		public override void Create(Curator item)
		{
			db.Curators.Add(item);
		}

		public override void Delete(int itemId)
		{
			throw new NotImplementedException();

		}

		public override void Delete(string itemName)
		{
			throw new NotImplementedException();
		}

		public override void Delete(Curator item)
		{
			db.Curators.Remove(item);
		}

		public Curator Get(int id)
		{
			throw new NotImplementedException();
		}
		public override Curator Get(Func<Curator, bool> func)
		{
			return db.Curators
						//.Include(at=>at.ExactClass)
						.Include(at => at.Group)
				.Include(at => at.Person)
				.FirstOrDefault(func);
		}

		public IEnumerable<Curator> GetAll()
		{
			throw new NotImplementedException();
			//return db.AuthUsers;
		}
		public override IEnumerable<Curator> GetAll(Func<Curator, bool> func)
		{
			return db.Curators
				.Include(at => at.Group)
				.Include(at => at.Person)
				.Where(func);
		}

		public override Curator OnExist(string name)
		{
			throw new NotImplementedException();
		}

		public override void Update(Curator item)
		{
			db.Curators.Update(item);

		}
	}
}