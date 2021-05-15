using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class ClassWorksRepo : IRepository<ClassWork>
	{
		public ClassWorksRepo(MyContext context) : base(context) { }


		public override void Create(ClassWork item)
		{
			db.ClassWorks.Add(item);
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
			db.ClassWorks.Remove(item);
		}

		public Attendance Get(int id)
		{
			throw new NotImplementedException();
		}
		public override ClassWork Get(Func<ClassWork, bool> func)
		{
			return db.ClassWorks
				//.Include(at=>at.ExactClass)
				.Include(at => at.ExactClass)
				.Include(at => at.WorkType)
				.FirstOrDefault(func);
		}

		public IEnumerable<ClassWork> GetAll()
		{
			throw new NotImplementedException();
			//return db.AuthUsers;
		}
		public override IEnumerable<ClassWork> GetAll(Func<ClassWork, bool> func)
		{
			return db.ClassWorks
				.Include(at => at.ExactClass)
				.Include(at => at.WorkType)
				.Where(func);
		}

		public override ClassWork OnExist(string name)
		{
			throw new NotImplementedException();
		}

		public override void Update(ClassWork item)
		{
			db.ClassWorks.Update(item);

		}
	}
}