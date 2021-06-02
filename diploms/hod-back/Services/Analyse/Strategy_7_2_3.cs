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
    public class Strategy_7_2_3 : Strategy
    {

        public string OldNum { get; set; }
        public string Num { get; set; }

        public Strategy_7_2_3()
        {
            this.OldNum = "7.2.3";
            this.Num = "4.4.5";
        }
        /// <summary>
        /// Подсчет преподавателей, подходящие под определение в требованиях ФГОС п.7.2.2
        /// </summary>
        /// <param name="items">Множество преподавателей</param>
        /// <returns></returns>
        public Requir Execute(UnitOfWork unit, int dir_id)
        {
            var Dir = unit.Directions.GetOrDefault(x => x.DirId == dir_id);

            List<TeacherLoadsView> dataLoads = unit.TeacherLoadsViews.GetMany(x => x.DirId == dir_id && x.EFormId == 1).ToList();

            var groupData = dataLoads.GroupBy(x => x.EmpId);

            var teachList = groupData.Select(x => x.Key);

            List<TeacherRate> dataRates = unit.TeacherRates.GetMany(x => teachList.Contains(x.EmpId)).ToList();
            List<TeacherSuitability> dataEDs = unit.TeacherSuitabilities.GetMany(x => teachList.Contains(x.EmpId)).ToList();
            List<BlockRec> dataRecs = unit.BlockRecs.GetMany(x => x.AcPlId == Dir.AcPlId).ToList();

            List<exTeacher> exList = new List<exTeacher>();

            foreach (var item in groupData)
            {
                exTeacher exT = new exTeacher();
                exT.Subs = new List<exSubject>();

                var item2 = item.ToList().GroupBy(x => x.SubId);
                var rate = dataRates.FirstOrDefault(x => x.EmpId == item.Key);
                var eDoc = dataEDs.FirstOrDefault(x => x.EmpId == item.Key);

                exT.DegId = eDoc.DegId;
                exT.RankId = eDoc.RankId;
                exT.IsForeign = rate.ApplyTId == 2;

                foreach (var item3 in item2.ToList())
                {
                    if (item3.Last().InPlan == 0) { continue; }

                    exSubject exS = new exSubject();

                    foreach (var tmp in item3)
                    {

                        float? value = 0;
                        switch (tmp.SubTId)
                        {
                            //case "лек":
                            case 1: // лек
                                {
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Les;
                                    exS.Les += (double)value;
                                    break;
                                }

                            //case "лаб":
                            case 2:
                                {
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Lab;
                                    exS.LabPr += (double)value;
                                    break;
                                }
                            //case "пр":
                            case 3:
                                {
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Pr;
                                    exS.LabPr += (double)value;
                                    break;
                                }

                            //case "из":
                            case 4:
                                {
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Iz;
                                    exS.Iz += (double)value;
                                    break;
                                }
                            //case "ак":
                            case 5:
                                {
                                    value = dataRecs.FirstOrDefault(x => x.BlockRecId == tmp.BlockRecId && x.SemestrNum == tmp.SemestrNum).Ak;
                                    exS.Ak += (double)value;
                                    break;
                                }
                        }
                    }
                    exT.Subs.Add(exS);
                }

                exList.Add(exT);
            }

            var items = unit.TeacherLoadSuitabilities.GetMany(x => x.DirId == dir_id);
            int numA = items.Count();

            //var status = exList.Where(x =>
            //    (Rules.isFgos_7_2_3(x.DegId, x.RankId))).Count();
            var status = exList.Where(x => x.is723_Part).Count();

            var fgos = unit.DirRequirs.GetOrDefault(x => x.DirId == dir_id && x.FgosNum == this.OldNum);

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

        public Requir Execute_Partial(UnitOfWork unit, Direction dir, IEnumerable<TeacherLoadSuitability> items, List<exTeacher> exList)
        {
            var fgos = unit.DirRequirs.GetOrDefaultAsync(x => x.DirId == dir.DirId && x.FgosNum == this.OldNum).Result;

            //int numA = items.Count();
            //int status = exList.Where(x => x.is723).Count();

            double numA = exList.Sum(x => x.TotalRate);
            double status = exList.Where(x => x.is723_Part).Sum(x => x.TotalRate);

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

            //int numA = items.Count();
            //int status = exList.Where(x => x.is723).Count();

            //double numA = exList.Sum(x => x.TotalRate);
            double status = exList.Where(x => x.is723_Part).Sum(x => x.TotalRate);

            Requir res = new Requir_7_2()
            {
                Num = this.Num,
                Discription = fgos.FgosPropertyView,
                //Value = null, // auto
                ValueNeeded = fgos.SettedValue,
                Direction = null,
                NumberAll = totalCount,
                NumberSuitable = status
            };

            return res;
        }


    }
}
