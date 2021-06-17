using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class DepDirsChartDto
    {
        public string name { get; set; }
        public ChartSeria[] series { get; set; }
    }

    public class ChartSeria
    {
        public string name { get; set; }
        public double value { get; set; }
    }
}
