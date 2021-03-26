using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.Model;

namespace hod_back.DAL.Repositories
{
    public class EducFormsRepository : IRepository<EducForm>
    {
        public EducFormsRepository(Context context) : base(context) { }


        public IEnumerable<EducForm> GetAll()
        {
            return db.EducForms;
        }

        public override IEnumerable<EducForm> GetMany(Func<EducForm, bool> func)
        {
            return db.EducForms.Where(func);
        }

    }
}
