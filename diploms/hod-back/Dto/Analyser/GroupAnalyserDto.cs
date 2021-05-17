using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto.Analyser
{
    public class GroupAnalyserDto
    {
        public int Group_id { get; set; }
        public int NumberAll { get; set; }
        public int NumberSubmitted { get; set; }
        //public int NumberAll2 { get; set; }
        //public int NumberSubmitted2 { get; set; }
        public float Value { get; set; }
        //public string Mark { get; set; }
    }
}
