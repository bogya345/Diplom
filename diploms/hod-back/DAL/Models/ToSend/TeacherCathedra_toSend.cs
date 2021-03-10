using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.DAL;
using hod_back.DAL.Contexts;

namespace hod_back.DAL.Models.ToSend
{
    public class Teachers_toSend : Employees
    {
        //public int id_teacherCath { get; set; }
        //public string teacher { get; set; }
        //public int id_cathedra { get; set; }
        //public int isHead { get; set; }
        //public DateTime dateIn { get; set; }
        //public DateTime? dateOut { get; set; }
        //public int id_applyType { get; set; }

        public Teachers_toSend()
        {

        }

        public Teachers_toSend(Context context, Employees item)
        {
            //this.id_employee = item.id_employee;

            //this.name_employee = item.

            //this.teacher = context.Employees
            //    .Where(x => x.id_employee == item.id_teacher)
            //    .FirstOrDefault().name_employee;

            //this.id_cathedra = item.id_cathedra;
            //this.dateIn = item.dateIn;
            //this.dateOut = item.dateOut;
            //this.id_applyType = item.id_applyType;
        }

        public override string ToString()
        {
            return name_employee.ToString();
        }
    }
}
