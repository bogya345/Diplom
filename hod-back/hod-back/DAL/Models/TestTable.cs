using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Models
{
    public class TestTable
    {
        public int id { get; set; }

        public string? nickname { get; set; }

        public double? price { get; set; }
    }
}
