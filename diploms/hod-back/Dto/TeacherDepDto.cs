using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class TeacherDepDto
    {
        public int Fsh_id { get; set; }
        public int Fh_id { get; set; }
        public int Emp_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }

        public string WorkT_name { get; set; }
        public string Post_name { get; set; }
        public int Dep_id { get; set; }
        public double StaffCount { get; set; }
        public DateTime DateBegin { get; set; }
    }
}
