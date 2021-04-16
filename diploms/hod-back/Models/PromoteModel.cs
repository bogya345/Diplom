using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Models
{
    public class PromoteModel
    {
        [FromForm(Name = "file")]
        public UserModel user { get; set; }

        [FromForm(Name = "promoted_fhs_id")]
        public int promoted_fhs_id { get; set; }

        [FromForm(Name = "message")]
        public string message { get; set; }
    }
}
