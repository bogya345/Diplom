using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class LoadDto
    {
        public int atAcPlId { get; set; }
        public int? FshId { get; set; }
        public string teachName { get; set; }
        public int BlocRecId { get; set; }
        public int? SemNum { get; set; }
        public int SubTypeId { get; set; }
        public string SubTypeName { get; set; }
        public double LoadValue { get; set; }
    }
}
