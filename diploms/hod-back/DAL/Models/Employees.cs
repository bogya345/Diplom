using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hod_back.DAL.Models
{
    /// <summary>
    /// should be epmloyees
    /// </summary>
    [Table("Employees", Schema = "Import")]
    public class Employees
    {
        [Key]
        public int id_employee { get; set; }
        public string name_employee { get; set; }
        public double rate { get; set; }
        public DateTime dateApply { get; set; }
        public DateTime? dateFired { get; set; }
        public string email { get; set; }
        public int id_department { get; set; }


        public override string ToString()
        {
            return id_employee.ToString();
        }
    }
}
