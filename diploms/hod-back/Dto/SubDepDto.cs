using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class SubDepDto
    {
        public int sub_id { get; set; }
        public string sub_name { get; set; }

        public int acPlDep_id { get; set; }
        public string acPlDep_name { get; set; }

        public int dep_id { get; set; }
        public string dep_name { get; set; }
    }
}
