using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class DepsInfoDto
    {
        public int Dep_id { get; set; }
        public string Dep_name { get; set; }
        public string Dep_shortName { get; set; }
        //dateCreated: Date,
        //dateEnd: Date
        public int HeadTeach_id { get; set; }
        public string HeadTeach_name { get; set; }
        public int Count_groups { get; set; }
    }
}
