using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class DepsDto
    {
        public int Dep_id { get; set; }
        public string Dep_name { get; set; }
        public DirectionDto[] Dirs { get; set; }
        //dateCreated: Date,
        //dateEnd: Date
    }
}
