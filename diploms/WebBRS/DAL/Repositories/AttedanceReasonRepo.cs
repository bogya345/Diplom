using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class AttedanceReasonRepo : IRepository<AttedanceReason>
	{
		public AttedanceReasonRepo(MyContext context) : base(context) { }


		public override void Create(AttedanceReason item)
		{
			db.AttedanceReasons

				.Add(item);
		}

		public override void Delete(int itemId)
		{
			throw new NotImplementedException();

		}

		public override void Delete(string itemName)
		{
			throw new NotImplementedException();
		}

		public override void Delete(AttedanceReason item)
		{
			db.AttedanceReasons
				//.Include(at=>at.ExactClass)

				.Remove(item);
		}

		public AttedanceReason Get(int id)
		{
			throw new NotImplementedException();
		}
		public override AttedanceReason Get(Func<AttedanceReason, bool> func)
		{
			return db.AttedanceReasons
				//.Include(at=>at.ExactClass)
				.Include(at => at.SGH)
				.Include(at => at.Curator)
				.Include(at => at.Person)
				.FirstOrDefault(func);
		}

		public IEnumerable<Attendance> GetAll()
		{
			throw new NotImplementedException();
			//return db.AuthUsers;
		}
		public override IEnumerable<AttedanceReason> GetAll(Func<AttedanceReason, bool> func)
		{
			return db.AttedanceReasons
				//.Include(at=>at.ExactClass)
				.Include(at => at.SGH)
				.Include(at => at.Curator)
				.Include(at => at.Person)
				.Where(func);
		}

		public override AttedanceReason OnExist(string name)
		{
			throw new NotImplementedException();
		}

		public override void Update(AttedanceReason item)
		{
			db.AttedanceReasons

				.Update(item);

		}
	}
}