using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;

namespace hod_back.DAL.Models.ToSend
{
    public class ClassGetProperty
    {
        public List<Groups> Groups { get; private set; }
        public List<Employees> TeachersCaths { get; private set; }

        public ClassGetProperty(UnitOfWork db, int currentCathedra)
        {
            try
            {
                //Groups = db.Groups.GetMany(x => x.DirectId == currentCathedra).ToList();
                //TeachersCaths = db.Employees.GetAllTeachers().ToList();
            }
            catch (Exception ex)
            {
                //
            }
        }

        //

    }
}
