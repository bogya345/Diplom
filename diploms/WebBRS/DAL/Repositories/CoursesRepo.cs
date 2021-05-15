using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
	public class CoursesRepo : IRepository<Course>
	{
		public CoursesRepo(MyContext context) : base(context) { }


		public override void Create(Course item)
		{
			db.Courses.Add(item);
		}

		public override void Delete(int itemId)
		{
			throw new NotImplementedException();

		}

		public override void Delete(string itemName)
		{
			throw new NotImplementedException();
		}

		public override void Delete(Course item)
		{
			db.Courses.Remove(item);
		}

		public Course Get(int id)
		{
			throw new NotImplementedException();
		}
		public override Course Get(Func<Course, bool> func)
		{
			return db.Courses
				//.Include(at=>at.ExactClass)
				.FirstOrDefault(func);
		}

		public IEnumerable<Course> GetAll()
		{
			return db.Courses;
			//return db.AuthUsers;
		}
		public override IEnumerable<Course> GetAll(Func<Course, bool> func)
		{
			return db.Courses
				.Where(func);
		}

		public override Course OnExist(string name)
		{
			throw new NotImplementedException();
		}

		public override void Update(Course item)
		{
			db.Courses.Update(item);

		}
	}
}
