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
    public class EducFormsRepository : IRepository<EducForms>
    {
        public EducFormsRepository(Context context) : base(context) { }


        public override void Create(EducForms item)
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

        public override void Delete(EducForms item)
        {
            throw new NotImplementedException();
        }

        public EducForms Get(int id)
        {
            throw new NotImplementedException();
        }
        public override EducForms Get(Func<EducForms, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EducForms> GetAll()
        {
            return db.EducForms;
        }
        public override IEnumerable<EducForms> GetMany(Func<EducForms, bool> func)
        {
            return db.EducForms.Where(func);
        }

        public override EducForms OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(EducForms item)
        {
            throw new NotImplementedException();
        }
    }
}
