using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.Views
{
    public class ViewTeacherLoad
    {
        public int teacherload_id_blockRec { get; set; }

        public string typeSubject { get; set; }
        public double? hours { get; set; }

        public int? id_employee { get; set; }
        
        public int blockrecs_id_blockRec { get; set; }

        public int id_group { get; set; }

        public int semestrNum { get; set; }

        public int InPlan { get; set; }

        public string blockNum { get; set; }

        public int id_subject { get; set; }

        public string subject { get; set; }

        public string name_employee { get; set; }

    }
}
