using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class ExactClassForLecturerRepo : IRepository<ExactClassForLecturerClass>
	{
		public ExactClassForLecturerRepo(MyContext context) : base(context) { }


		public override void Create(ExactClassForLecturerClass item)
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

		public override void Delete(ExactClassForLecturerClass item)
		{
			throw new NotImplementedException();
		}

		public ExactClassForLecturerClass Get(int id)
		{
			throw new NotImplementedException();
		}
		public override ExactClassForLecturerClass Get(Func<ExactClassForLecturerClass, bool> func)
		{
			return db.ExactClassForLecturerClasses
				.Include(ecflc=>ecflc.ExactClasses)
				
				.Include(ecflc=>ecflc.Lecturer).FirstOrDefault(func);
		}

		public IEnumerable<Attendance> GetAll()
		{
			throw new NotImplementedException();
			//return db.AuthUsers;
		}
		public override IEnumerable<ExactClassForLecturerClass> GetAll(Func<ExactClassForLecturerClass, bool> func)
		{
			return db.ExactClassForLecturerClasses.Where(func);
		}

		public override ExactClassForLecturerClass OnExist(string name)
		{
			throw new NotImplementedException();
		}

		public override void Update(ExactClassForLecturerClass item)
		{
			throw new NotImplementedException();
		}
	}
}
