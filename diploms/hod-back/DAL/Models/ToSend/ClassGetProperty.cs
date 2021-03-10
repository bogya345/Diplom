using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;

using hod_back.DAL;
using hod_back.DAL.Contexts;

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
                Groups = db.Groups.GetAll(x => x.id_department == currentCathedra).ToList();
                TeachersCaths = db.Employees.GetAllTeachers().ToList();
            }
            catch (Exception ex)
            {
                //
            }
        }

        //

    }
}
