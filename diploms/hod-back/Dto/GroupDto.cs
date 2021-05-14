using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class GroupDto
    {
        public int group_id { get; set; }
        public string group_name { get; set; }
        public int? group_acPlan_id { get; set; }

        //public int NumberAll { get; set; }
        //public int NumberSubmited { get; set; }
    }
}
