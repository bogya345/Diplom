using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class SubjectLecturerRepo : IRepository<SubjectLecturer>
	{
		public SubjectLecturerRepo(MyContext context) : base(context) { }


		public override void Create(SubjectLecturer item)
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

		public override void Delete(SubjectLecturer item)
		{
			throw new NotImplementedException();
		}

		public Attendance Get(int id)
		{
			throw new NotImplementedException();
		}
		public override SubjectLecturer Get(Func<SubjectLecturer, bool> func)
		{
			return db.SubjectLecturers.FirstOrDefault(func);
		}

		public IEnumerable<SubjectLecturer> GetAll()
		{
			throw new NotImplementedException();
			//return db.AuthUsers;
		}
		public override IEnumerable<SubjectLecturer> GetAll(Func<SubjectLecturer, bool> func)
		{
			return db.SubjectLecturers.Where(func);
		}

		public override SubjectLecturer OnExist(string name)
		{
			throw new NotImplementedException();
		}

		public override void Update(SubjectLecturer item)
		{
			throw new NotImplementedException();
		}

	}
}
