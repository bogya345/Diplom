using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Models
{
    public class UserModel
    {
        [FromForm(Name = "login")]
        public string login { get; set; }

        [FromForm(Name = "fsh_id")]
        public string fsh_id { get; set; }

        [FromForm(Name = "emp_id")]
        public string emp_id { get; set; }

        [FromForm(Name = "role_id")]
        public bool role_id { get; set; }
    }
}
