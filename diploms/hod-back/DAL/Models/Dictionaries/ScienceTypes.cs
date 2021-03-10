using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("ScienceTypes", Schema = "Import")]
    public class ScienceTypes : Dictionary
    {
        public int scienceType_id { get; set; }
        public string scienceType_name { get; set; }
        public string scienceTypeAbbrev { get; set; }
        public string scienceTypeShortName { get; set; }
    }
}
