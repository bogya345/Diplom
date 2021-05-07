using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBRS.Models;

namespace WebBRS.DAL.Repositories
{
    public class AttendancesRepo : IRepository<Attendance>
    {
        public AttendancesRepo(MyContext context) : base(context) { }


        public override void Create(Attendance item)
        {
           db.Attendances.Add(item);
        }

        public override void Delete(int itemId)
        {
            throw new NotImplementedException();

        }

        public override void Delete(string itemName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Attendance item)
        {
            db.Attendances.Remove(item); 
        }

        public Attendance Get(int id)
        {
            throw new NotImplementedException();
        }
        public override Attendance Get(Func<Attendance, bool> func)
        {
            return db.Attendances.FirstOrDefault(func);
        }

        public IEnumerable<Attendance> GetAll()
        {
            throw new NotImplementedException();
            //return db.AuthUsers;
        }
        public override IEnumerable<Attendance> GetAll(Func<Attendance, bool> func)
        {
            return db.Attendances.Where(func);
        }

        public override Attendance OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Attendance item)
        {
            throw new NotImplementedException();
        }
    }
}
