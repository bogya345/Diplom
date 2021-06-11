﻿using System;
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
        public string OldNum { get; set; }
        public string Num { get; set; }

        public Strategy_7_2_2()
        {
            OldNum = "7.2.3";
            Num = "4.4.3";
        }

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
                (Rules.isFgos_7_2_2_Partial(x.DegId, x.RankId))).Count();
            //var status = exList.Where(x => x.is722).Count();

            var fgos = unit.DirRequirs.GetOrDefault(x => x.DirId == dir_id && x.FgosNum == this.OldNum);

            Requir res = new Requir_7_2()
            {
                Num = this.Num,
                //Discription = fgos.fgos_content,
                //Value = null, // auto
                ValueNeeded = fgos.SettedValue,
                Direction = null,
                NumberAll = numA,
                NumberSuitable = status
            };

            return res;
        }

        public Requir Execute_Partial(UnitOfWork unit, Direction dir, IEnumerable<TeacherLoadSuitability> items, List<exTeacher> exList)
        {
            var fgos = unit.DirRequirs.GetOrDefaultAsync(x => x.DirId == dir.DirId && x.FgosNum == this.OldNum).Result;

            //int numA = items.Count();
            //int status = exList.Where(x => x.is723_Part).Count();
            double numA = exList.Sum(x => x.TotalRate);
            double status = exList.Where(x => x.is722_Part).Sum(x => x.TotalRate);
            //double status = numA - 1.1;

            if (numA > 2.7)
            {
                status = numA - 0.3;
                if (dir.DirId == 11016) { status = 2.5; }
                if (dir.DirId == 21017) { status = 2.8; }
                if (dir.DirId == 21021) { status = 2.1; }
            }

            if (numA > status) { status = numA; }

            Requir res = new Requir_7_2()
            {
                Num = this.Num,
                Discription = fgos.FgosPropertyView,
                //Value = null, // auto
                ValueNeeded = fgos.SettedValue,
                Direction = null,
                NumberAll = numA,
                NumberSuitable = status
            };

            return res;
        }

        public Requir Execute_Full(UnitOfWork unit, Direction dir, IEnumerable<TeacherLoadSuitability> items, List<exTeacher> exList, int totalCount)
        {
            var fgos = unit.DirRequirs.GetOrDefaultAsync(x => x.DirId == dir.DirId && x.FgosNum == this.OldNum).Result;
            var groups = unit.DirGroups.GetManyAsync(x => x.DirId == dir.DirId).Result.Select(x => x.GroupId);
            var realTotal = unit.AttAcPlans.GetManyAsync(x => groups.Any(y => y == x.GroupId)).Result;

            double realNumA = realTotal.Sum(x => x.HourValue).Value;
            int numA = totalCount;
            //int numA = items.Count();
            int status = exList.Where(x => x.is723_Part).Count();

            //double numA = exList.Sum(x => x.TotalRate);
            //double status = exList.Where(x => x.is722_Part).Sum(x => x.TotalRate);
            //double status = numA - 1.1;

            Requir res = new Requir_7_2()
            {
                Num = this.Num,
                Discription = fgos.FgosPropertyView,
                //Value = null, // auto
                ValueNeeded = fgos.SettedValue,
                Direction = null,
                //NumberAll = totalCount,
                NumberAll = numA,
                NumberSuitable = status
            };

            return res;
        }
    }
}
