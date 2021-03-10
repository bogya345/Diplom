//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using Microsoft.EntityFrameworkCore;

//using HeadOfDepartment.Models;
//using HeadOfDepartment.Models.Dictionaries;

//using HeadOfDepartment.DAL.Contexts;

//namespace HeadOfDepartment.DAL.Repositories
//{
//    public class TeacherCathedrasRepository : IRepository<TeacherCathedra>
//    {
//        public TeacherCathedrasRepository(Context context) : base(context) { }

//        public override void Create(TeacherCathedra item)
//        {
//            throw new NotImplementedException();
//        }

//        public override void Delete(int itemId)
//        {
//            throw new NotImplementedException();
//        }

//        public override void Delete(string itemName)
//        {
//            throw new NotImplementedException();
//        }

//        public override void Delete(TeacherCathedra item)
//        {
//            throw new NotImplementedException();
//        }

//        public TeacherCathedra Get(int id)
//        {
//            throw new NotImplementedException();
//        }
//        public override TeacherCathedra Get(Func<TeacherCathedra, bool> func)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<TeacherCathedra> GetAll()
//        {
//            return db.TeacherCathedras;
//        }

//        public override IEnumerable<TeacherCathedra> GetAll(Func<TeacherCathedra, bool> func)
//        {
//            throw new NotImplementedException();
//        }

//        public override TeacherCathedra OnExist(string name)
//        {
//            throw new NotImplementedException();
//        }

//        public override void Update(TeacherCathedra item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
