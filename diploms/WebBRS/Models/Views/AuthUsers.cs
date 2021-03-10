using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBRS.Models.Views
{
    [Keyless]
    public class AuthUsers
    {
        public int id_employee { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public int id_department { get; set; }

        public string name_department { get; set; }

        public int id_role { get; set; }

        public string name_role { get; set; }

        public int id_role_actual { get; set; }

        public string name_role_actual { get; set; }
    }
}
