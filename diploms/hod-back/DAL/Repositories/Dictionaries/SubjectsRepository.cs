using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class SubjectsRepository : IRepository<Subject>
    {
        public SubjectsRepository(Context context) : base(context) { }

        private object _locker = new object();

        public override void Create(Subject item) { db.Subjects.Add(item); }

        public override void CreateRange(Subject[] items) { db.Subjects.AddRange(items); }

        public override Subject GetOrDefault(Func<Subject, bool> func, Subject def = null)
        {
            return db.Subjects.FirstOrDefault(func) ?? def;
        }

        public IEnumerable<Subject> GetAll()
        {
            return db.Subjects;
        }

        public override IEnumerable<Subject> GetMany(Func<Subject, bool> func)
        {
            return db.Subjects.Where(func);
        }

        public override IEnumerable<Subject> GetManyWithInclude(Func<Subject, bool> func)
        {
            var tmp = db.Subjects
                .Include(x => x.AcPlDep)
                .ThenInclude(y => y.Dep)
                .Where(func)
                .ToList()
                ;
            return tmp;
        }
        public override async Task<IEnumerable<Subject>> GetManyWithIncludeAsync(Func<Subject, bool> func)
        {

        pls:
            try
            {
                var tmp = db.Subjects
                .Include(x => x.AcPlDep)
                .ThenInclude(y => y.Dep)
                .Where(func)
                ;
                return tmp.ToList();
            }
            catch (InvalidOperationException ex)
            {
                await Task.Delay(1000);
                goto pls;
            }
            return null;

            //IEnumerable<Subject> GetData()
            //{
            //    foreach (var i in tmp) { yield return i; }
            //}

            //return GetData();
        }

        //public async List<Subject> GetList(IEnumerable)
        //{

        //}

        public override Subject OnExist(string name)
        {
            return db.Subjects.Where(x => x.SubName == name).FirstOrDefault();
        }

    }
}
