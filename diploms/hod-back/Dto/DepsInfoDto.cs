using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class DepsInfoDto
    {
        public int dep_id { get; set; }
        public string dep_name { get; set; }
        //dateCreated: Date,
        //dateEnd: Date
        public int headTeach_id { get; set; }
        public string headTeach_name { get; set; }
        public int count_groups { get; set; }
    }
}
