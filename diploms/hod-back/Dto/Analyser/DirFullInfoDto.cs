using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto.Analyser
{
    public class DirInfoDto
    {
        public int dir_id { get; set; }
        public int groupCount { get; set; }

        public DirFgosAnalyserDto[] indicators { get; set; }
    }

    public class DirFgosAnalyserDto
    {
        public int fgos_id { get; set; }
        public string fgos_num { get; set; }
        public int progressValue { get; set; }
    }
}
