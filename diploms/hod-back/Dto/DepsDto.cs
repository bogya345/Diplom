using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class DepsDto
    {
        public int dep_id { get; set; }
        public string dep_name { get; set; }
        public DirectionDto[] dirs { get; set; }
        //dateCreated: Date,
        //dateEnd: Date
    }
}
