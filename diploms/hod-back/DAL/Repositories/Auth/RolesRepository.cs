using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;
using hod_back.DAL.Models.Views;

using hod_back.Model;

namespace hod_back.DAL.Repositories.Auth
{
    public class RolesRepository : IRepository<Role>
    {
        public RolesRepository(Context context) : base(context) { }

    }
}
