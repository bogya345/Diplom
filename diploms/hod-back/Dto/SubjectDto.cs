using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class SubjectDto
    {
        public string SubjectName { get; set; }
        public DepsDto CorrespDep { get; set; }
        public int? SemestrNum { get; set; }
        public LoadDto[] Loads { get; set; }
    }
}
