using hod_back.DAL;
using hod_back.Dto.Analyser.FgosRequirs;
using hod_back.Model;
using hod_back.Services.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Services.Analyse
{
    public interface Strategy
    {
        /// <summary>
        /// Подсчет преподавателей, подходящие под определение в требованиях ФГОС п. *
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public Requir Execute(UnitOfWork unit, int dir_id);
        //public Requir Execute(IEnumerable<TeacherLoadSuitability> items, UnitOfWork unit);

        public Requir Execute(UnitOfWork unit, Direction dir, IEnumerable<TeacherLoadSuitability> items, List<exTeacher> exList);
    }
}
