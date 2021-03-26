//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using Microsoft.EntityFrameworkCore;

//using hod_back.Model;

//namespace hod_back.DAL.Repositories
//{
//    public class ViewTeacherLoadRepository : IRepository<ViewTeacherLoad>
//    {
//        public ViewTeacherLoadRepository(Context context) : base(context) { }

//        public override void Create(ViewTeacherLoad item)
//        {
//            db.ViewTeacherLoad.Add(item);
//        }

//        public override void Delete(int itemId)
//        {
//            throw new NotImplementedException();
//        }

//        public override void Delete(string itemName)
//        {
//            throw new NotImplementedException();
//        }

//        public override void Delete(ViewTeacherLoad item)
//        {
//            throw new NotImplementedException();
//        }

//        public ViewTeacherLoad Get(int id)
//        {
//            throw new NotImplementedException();
//        }
//        public override ViewTeacherLoad Get(Func<ViewTeacherLoad, bool> func)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<ViewTeacherLoad> GetAll()
//        {
//            throw new NotImplementedException();
//            //return db.ViewTeacherLoad;
//        }
//        public override IEnumerable<ViewTeacherLoad> GetMany(Func<ViewTeacherLoad, bool> func)
//        {
//            List<ViewTeacherLoad> tmp_ = db.ViewTeacherLoad.Take(100).ToList();

//            List<ViewTeacherLoad> tmp = db.ViewTeacherLoad.Where(func).ToList();
//            return tmp;
//        }

//        public override ViewTeacherLoad OnExist(string name)
//        {
//            throw new NotImplementedException();
//        }

//        public override void Update(ViewTeacherLoad item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
