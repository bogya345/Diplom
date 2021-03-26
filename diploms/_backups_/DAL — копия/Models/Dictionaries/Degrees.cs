using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("Degrees", Schema = "Import")]
    public class Degrees
    {
        public int degree_id { get; set; }
        public string degree_name { get; set; }
        public string degreeShortName { get; set; }
        public string degreeAbbrev { get; set; }
        public int degreeOrder { get; set; }
    }
}
