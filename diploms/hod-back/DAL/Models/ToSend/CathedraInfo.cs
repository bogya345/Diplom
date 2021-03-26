using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL;
using hod_back.DAL.Models.Views;

namespace hod_back.DAL.Models.ToSend
{
    public class CathedraInfo
    {
        public Departments cathedra { get; private set; }
        public List<Groups> groups { get; private set; }

        // need a user to send his cathedras info
        public CathedraInfo(string user_dep_id, string user_name = "")
        {
            UnitOfWork unit = new UnitOfWork();

            int dep_id = Convert.ToInt32(value: user_dep_id);

            //List<CathInfo> tmp = unit.CathInfo.GetMany(x => x.id_cathedra == dep_id).ToList();
            //this.cathedra = unit.Departments.Get(x => x.dep_id == dep_id);
            //this.groups = unit.Groups.GetMany(x => x.id_department == dep_id).ToList();
            if (this.cathedra == null) { throw new Exception(); }

        }

        private class User
        {
            public string name { get; set; }
            public Departments cathedra { get; set; }
        }
    }

}
