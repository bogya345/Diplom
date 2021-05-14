using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class MapSudDep
    {
        public SubDepDto[] subDeps { get; set; }
        public DepDepDto[] depDep { get; set; }
        public DepsDto[] deps { get; set; }
    }
}
