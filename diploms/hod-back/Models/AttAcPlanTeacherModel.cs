using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Models
{
    public class AttAcPlanTeacherModel
    {
        [FromForm(Name = "fsh_id")]
        public int fsh_id { get; set; }

        [FromForm(Name = "teacherName")]
        public string teacherName { get; set; }

        [FromForm(Name = "attAcPlan_id")]
        public int attAcPlan_id { get; set; }
    }
}
