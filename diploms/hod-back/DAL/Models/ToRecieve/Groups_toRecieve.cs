using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.DAL.Models.ToRecieve
{
    public class Groups_toRecieve
    {
        //public int id_group { get; set; }

        /// <summary>
        /// название группы
        /// </summary>
        public string name_group { get; set; }

        /// <summary>
        /// год поступления
        /// </summary>
        public string startYear { get; set; }

        /// <summary>
        /// ID квалификации
        /// </summary>
        public int id_qualification { get; set; }

        /// <summary>
        /// ID формы обучения
        /// </summary>
        public int id_educForm { get; set; }

        /// <summary>
        /// ID кафедры (хотелось бы чтобы она бралась с бэка)
        /// </summary>
        public int id_cathedra { get; set; }
    }
}
