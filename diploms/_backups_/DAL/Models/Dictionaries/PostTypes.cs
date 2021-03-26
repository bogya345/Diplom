using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace hod_back.DAL.Models.Dictionaries
{
    [Table("PostTypes", Schema = "Import")]
    public class PostTypes
    {
        public int postType_id { get; set; }
        public string postType_name { get; set; }
    }
}
