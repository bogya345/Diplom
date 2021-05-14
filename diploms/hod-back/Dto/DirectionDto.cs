using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class DirectionDto
    {
        public int dir_id { get; set; }
        public string dir_name { get; set; }
        public string startYear { get; set; }
        public int? acPl_id { get; set; }
        // mb link on plan (as excel)
        public DirRequirDto[] requirs { get; set; }
        public GroupDto[] groups { get; set; }

    }
}
