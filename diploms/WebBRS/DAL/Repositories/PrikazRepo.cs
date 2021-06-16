using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class PrikazRepo : IRepository<Prikaz>
	{
		public PrikazRepo(MyContext context) : base(context) { }


		public override void Create(Prikaz item)
		{
			db.Prikazes.Add(item);
		}

		public override void Delete(int itemId)
		{
			throw new NotImplementedException();

		}

		public override void Delete(string itemName)
		{
			throw new NotImplementedException();
		}

		public override void Delete(Prikaz item)
		{
			db.Prikazes.Remove(item);
		}

		public Curator Get(int id)
		{
			throw new NotImplementedException();
		}
		public override Prikaz Get(Func<Prikaz, bool> func)
		{
			return db.Prikazes
								//.Include(at=>at.ExactClass)
								.Include(at => at.RowsForSend)
						.Include(at => at.StudyYear)
				.FirstOrDefault(func);
		}

		public IEnumerable<Prikaz> GetAll()
		{
			return db.Prikazes
						//.Include(at=>at.ExactClass)
						.Include(at=>at.RowsForSend)
						.Include(at => at.StudyYear);
			//return db.AuthUsers;
		}
		public override IEnumerable<Prikaz> GetAll(Func<Prikaz, bool> func)
		{
			return db.Prikazes
					.Include(at => at.StudyYear)
				.Where(func);
		}

		public override Prikaz OnExist(string name)
		{
			throw new NotImplementedException();
		}

		public override void Update(Prikaz item)
		{
			db.Prikazes.Update(item);

		}
	}
}
	
