using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class GroupTeacherDto
    {
        public string letter { get; set; }
        public TeacherDepDto[] teachers { get; set; }
    }
}
