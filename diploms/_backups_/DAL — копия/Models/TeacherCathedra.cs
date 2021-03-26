//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

//namespace HeadOfDepartment.Models
//{
//    public partial class TeacherCathedra
//    {
//        [Key]
//        public int id_teacherCath { get; set; }
//        public int id_teacher { get; set; }
//        public int id_cathedra { get; set; }
//        public DateTime dateIn { get; set; }
//        public DateTime? dateOut { get; set; }
//        public int id_applyType { get; set; }

//        // old field 
//        //public int isHead { get; set; }


//        public override string ToString()
//        {
//            return id_teacherCath.ToString();
//        }
//    }
//}
