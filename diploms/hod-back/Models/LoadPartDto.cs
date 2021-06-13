using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Models
{
    public class LoadPartDto
    {
        public int Fsh_id { get; set; }
        public string TeacherName { get; set; }

        public int? Fsh_id2 { get; set; }
        public string TeacherName2 { get; set; }
    }
}
