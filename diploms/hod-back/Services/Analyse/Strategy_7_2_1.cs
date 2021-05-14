using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;
using hod_back.Dto.Analyser.FgosRequirs;
using hod_back.DAL;
using hod_back.Services.Excel;

namespace hod_back.Services.Analyse
{
    public class Strategy_7_2_1 : Strategy
    {
        /// <summary>
        /// Подсчет преподавателей, подходящие под определение в требованиях ФГОС п.7.2.1
        /// </summary>
        /// <param name="items">Множество преподавателей</param>
        /// <returns></returns>
        public Requir Execute(UnitOfWork unit, int dir_id)
        {
            var items = unit.TeacherLoadSuitabilities.GetMany(x => x.DirId == dir_id);

            List<int> degs_needed = new List<int>() { 2, 3 };   // 2-д-р наук, 3-кандидат наук
            List<int> ranks_needed = new List<int>() { 4 }; // 4-доцент

            var status = items.Where(x =>
                (x.DegId.HasValue && degs_needed.Contains(x.DegId.Value))
                || (x.RankId.HasValue && ranks_needed.Contains(x.RankId.Value))
                ).Count();

            Requir res = new Requir_7_2()
            {
                Num = "7.2.1",
                //Discription = ,
                //Value = null,
                //ValueNeeded = null,
                //Direction = null,
                NumberAll = items.Count(),
                NumberSuitable = status
            };

            return res;
        }

        public Requir Execute(UnitOfWork unit, Direction dir, IEnumerable<TeacherLoadSuitability> items, List<exTeacher> exList)
        {
            throw new NotImplementedException();
        }
    }
}
