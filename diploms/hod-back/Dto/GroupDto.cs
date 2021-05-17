using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class GroupDto
    {
        public int Group_id { get; set; }
        public string Group_name { get; set; }
        public int? Group_acPlan_id { get; set; }

        //public int NumberAll { get; set; }
        //public int NumberSubmited { get; set; }
    }
}
