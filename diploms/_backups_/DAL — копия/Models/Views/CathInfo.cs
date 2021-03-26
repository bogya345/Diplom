using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hod_back.DAL.Models.Views
{
    public class CathInfo
    {
        /// <summary>
        /// ID кафедры
        /// </summary>
        [Column("idDep")]
        public int id_cathedra { get; set; }

        /// <summary>
        /// Название кафедры
        /// </summary>
        [Column("nameDep")]
        public string name_cathedra { get; set; }


        /// <summary>
        /// ID сотрудника (который является заведующим отделом (или кафедрой))
        /// </summary>
        [Column("idHead")]
        public int Head_id_teacher { get; set; }

        /// <summary>
        /// ФИО преподавателя (который является заведующим кафедрой)
        /// </summary>
        [Column("nameHead")]
        public string Head_name_teacher { get; set; }

        /// <summary>
        /// Количество групп на кафедре
        /// </summary>
        [Column("count")]
        public int count_groups { get; set; }
    }
}
