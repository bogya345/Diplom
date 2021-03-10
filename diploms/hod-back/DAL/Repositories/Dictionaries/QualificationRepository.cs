using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;

using hod_back.DAL.Contexts;

namespace hod_back.DAL.Repositories
{
    public class QualificationRepository : IRepository<Qualifications>
    {
        public QualificationRepository(Context context) : base(context) { }


        public override void Create(Qualifications item)
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

        public override void Delete(Qualifications item)
        {
            throw new NotImplementedException();
        }

        public Qualifications Get(int id)
        {
            throw new NotImplementedException();
        }
        public override Qualifications Get(Func<Qualifications, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Qualifications> GetAll()
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Qualifications> GetAll(Func<Qualifications, bool> func)
        {
            return db.Qualifications.Where(func);
        }

        public override Qualifications OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Qualifications item)
        {
            throw new NotImplementedException();
        }
    }
}
