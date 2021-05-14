using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using hod_back.Model;
using hod_back.Dto.Analyser.FgosRequirs;
using hod_back.DAL;
using hod_back.misc;
using hod_back.Services.Excel;

namespace hod_back.Services.Analyse
{
    public class Strategy_7_2_2 : Strategy
    {
        /// <summary>
        /// Подсчет преподавателей, подходящие под определение в требованиях ФГОС п.7.2.2
        /// </summary>
        /// <param name="items">Множество преподавателей</param>
        /// <returns></returns>
        public Requir Execute(UnitOfWork unit, int dir_id)
        {

            var Dir = unit.Directions.GetOrDefault(x => x.DirId == dir_id);

            var items = unit.TeacherLoadSuitabilities.GetMany(x => x.DirId == dir_id);
            int numA = items.Count();

            var status = items.Where(x =>
                (Rules.isFgos_7_2_2(x.DegId, x.RankId))).Count();
            //var status = exList.Where(x => x.is722).Count();

            var fgos = unit.DirRequirs.GetOrDefault(x => x.DirId == dir_id && x.FgosNum == "7.2.2");

            Requir res = new Requir_7_2()
            {
                Num = "7.2.2",
                //Discription = fgos.fgos_content,
                //Value = null, // auto
                ValueNeeded = fgos.SettedValue,
                Direction = null,
                NumberAll = numA,
                NumberSuitable = status
            };

            return res;
        }

        public Requir Execute(UnitOfWork unit, Direction dir, IEnumerable<TeacherLoadSuitability> items, List<exTeacher> exList)
        {
            var fgos = unit.DirRequirs.GetOrDefault(x => x.DirId == dir.DirId && x.FgosNum == "7.2.2");

            int numA = items.Count();
            int status = exList.Where(x => x.is723).Count();

            Requir res = new Requir_7_2()
            {
                Num = "7.2.2",
                Discription = fgos.FgosPropertyView,
                //Value = null, // auto
                ValueNeeded = fgos.SettedValue,
                Direction = null,
                NumberAll = numA,
                NumberSuitable = status
            };

            return res;
        }
    }
}
