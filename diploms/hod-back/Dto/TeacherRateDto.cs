using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Dto
{
    public class TeacherRateDto
    {
        public int FshId { get; set; }
        public float? StaffCount { get; set; }
        public int FsId { get; set; }
        public int? WorkTId { get; set; }
        public string WorkTName { get; set; }
        public string WorkTShortname { get; set; }
        public int? PsId { get; set; }
        public int? PostId { get; set; }
        public int? DepId { get; set; }
        public string PostName { get; set; }
        public int EmpId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
    }
}
