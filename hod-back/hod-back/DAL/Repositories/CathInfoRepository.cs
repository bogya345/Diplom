using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;
using hod_back.DAL.Models.Views;

using hod_back.DAL.Contexts;

namespace hod_back.DAL.Repositories
{
    public class CathInfoRepository : IRepository<CathInfo>
    {
        public CathInfoRepository(Context context) : base(context) { }


        public override void Create(CathInfo item)
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

        public override void Delete(CathInfo item)
        {
            throw new NotImplementedException();
        }

        public CathInfo Get(int id)
        {
            throw new NotImplementedException();
        }
        public override CathInfo Get(Func<CathInfo, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CathInfo> GetAll()
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<CathInfo> GetAll(Func<CathInfo, bool> func)
        {
            return db.CathInfo.Where(func);
        }

        public override CathInfo OnExist(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(CathInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
