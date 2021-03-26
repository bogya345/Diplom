using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace hod_back.DAL.Models
{
    public class TableTest
    {
        [Key]
        public Int64 ID_KEK { get; set; }
        public string NAME_KEK { get; set; }
    }
}
