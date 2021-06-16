using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class PrikazRowRepo : IRepository<PrikazRow>
	{
		public PrikazRowRepo(MyContext context) : base(context) { }


		public override void Create(PrikazRow item)
		{
			db.PrikazRows.Add(item);
		}

		public override void Delete(int itemId)
		{
			throw new NotImplementedException();

		}

		public override void Delete(string itemName)
		{
			throw new NotImplementedException();
		}

		public override void Delete(PrikazRow item)
		{
			db.PrikazRows.Remove(item);
		}

		public Curator Get(int id)
		{
			throw new NotImplementedException();
		}
		public override PrikazRow Get(Func<PrikazRow, bool> func)
		{
			return db.PrikazRows
					.Include(at => at.Group)
					.Include(at => at.Prikaz)
				.FirstOrDefault(func);
		}

		public IEnumerable<PrikazRow> GetAll()
		{
			throw new NotImplementedException();
			//return db.AuthUsers;
		}
		public override IEnumerable<PrikazRow> GetAll(Func<PrikazRow, bool> func)
		{
			return db.PrikazRows
					.Include(at => at.Group)
					.Include(at => at.Prikaz)
				.Where(func);
		}

		public override PrikazRow OnExist(string name)
		{
			throw new NotImplementedException();
		}

		public override void Update(PrikazRow item)
		{
			db.PrikazRows.Update(item);

		}
	}
}

