using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("EducDocTypes", Schema = "Import")]
    public class EducDocTypes
    {
        public int educDocType_id { get; set; }
        public string educDocType_name { get; set; }
        public int isOld { get; set; }
    }
}
