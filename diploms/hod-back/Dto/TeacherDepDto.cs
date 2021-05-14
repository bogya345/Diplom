using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class TeacherDepDto
    {
        public int fsh_id { get; set; }
        public int fh_id { get; set; }
        public int emp_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string fullName { get; set; }

        public string workT_name { get; set; }
        public string post_name { get; set; }
        public int dep_id { get; set; }
        public double staffCount { get; set; }
        public DateTime dateBegin { get; set; }
    }
}
