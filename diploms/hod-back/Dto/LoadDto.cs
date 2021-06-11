using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class LoadDto
    {
        public int AtAcPlId { get; set; }
        public int? FshId { get; set; }
        public int? FshId1 { get; set; }
        public int? FshId2 { get; set; }
        public string TeachName { get; set; }
        public string TeachName1 { get; set; }
        public string TeachName2 { get; set; }
        public int BlocRecId { get; set; }
        public int? SemNum { get; set; }
        public int SubTypeId { get; set; }
        public string SubTypeName { get; set; }
        public double LoadValue { get; set; }
    }
}
