using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class DirectionDto
    {
        public int Dir_id { get; set; }
        public string Dir_name { get; set; }
        public string StartYear { get; set; }
        public int? AcPl_id { get; set; }
        // mb link on plan (as excel)
        public DirRequirDto[] Requirs { get; set; }
        public GroupDto[] Groups { get; set; }

    }
}
