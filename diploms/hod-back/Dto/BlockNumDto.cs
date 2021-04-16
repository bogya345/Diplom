using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class BlockNumDto
    {
        public int BlockNumId { get; set; }
        public string BlockName { get; set; }
        public SubjectDto[] Subjects { get; set; }
    }
}
