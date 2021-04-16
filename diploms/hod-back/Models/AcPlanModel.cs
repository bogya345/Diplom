using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Models
{
    public class AcPlanModel
    {
        [FromForm(Name = "file")]
        public IFormFile file { get; set; }

        [FromForm(Name = "reportProgress")]
        public bool reportProgress { get; set; }

        [FromForm(Name = "message")]
        public string message { get; set; }
    }
}
