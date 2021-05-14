using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Models
{
    public class SubDepModels
    {
        public SubDepModel[] clust { get; set; }
        //public string message { get; set; }
    }

    public class SubDepModel
    {
        public int sub_id { get; set; }
        public int acPlDep_id { get; set; }
        public int dep_id { get; set; }
    }
}
