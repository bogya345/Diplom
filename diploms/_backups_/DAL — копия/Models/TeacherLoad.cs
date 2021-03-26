using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models
{
    [Table("TeacherLoad", Schema = "dbo")]
    public class TeacherLoad
    {
        //[Key]
        //public int id_teacherLoad { get; set; }

        [ForeignKey("BlockRecs")]
        public int id_blockRec { get; set; }    // key

        public string typeSubject { get; set; } // key

        public double hours { get; set; }

        [ForeignKey("Employee")]
        public int? id_employee { get; set; } // key
    }
}
