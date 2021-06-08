using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class DirectionDto
    {
        public int? Dir_id { get; set; }
        public string? Dir_name { get; set; }
        public string? StartYear { get; set; }
        public int? AcPl_id { get; set; }
        public Status Status { get; set; }
        public string Status_msg
        {
            get
            {
                if (Status == null) { return "-"; }
                if (Status.Status_down == null) { return "-"; }
                return $"{Status.Status_up}/{Status.Status_down}";
            }
        }
        // mb link on plan (as excel)
        public DirRequirDto[] Requirs { get; set; }
        public GroupDto[] Groups { get; set; }

    }
    public class Status
    {
        public int? Status_up { get; set; }
        public int? Status_down { get; set; }
    }
}
