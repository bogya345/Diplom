using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.Dictionaries
{
    public class QualificationTypes
    {
        public int id_qualifacation { get; set; }
        public string name_qualification { get; set; }
    }
}
