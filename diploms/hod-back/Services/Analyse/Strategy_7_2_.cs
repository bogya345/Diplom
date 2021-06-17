using hod_back.DAL;
using hod_back.Model;
using hod_back.Services.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hod_back.Services.Analyse
{
    public class Strategy_7_2_
    {
        public Direction Dir { get; set; }

        public IEnumerable<TeacherLoadSuitability> items { get; set; }
        public List<exTeacher> exList { get; set; }

        public int TotalCount { get; set; }

        public bool isFull { get; set; }

        public Strategy_7_2_()
        {
            //items
            exList = new List<exTeacher>();
        }

        public bool StoreIt(UnitOfWork unit, int dir_id)
        {
            this.Dir = unit.Directions.GetOrDefault(x => x.DirId == dir_id);

            if (Dir != null && Dir.DirId != dir_id) { return false; }

            if (!unit.BlockRecs.OnExist(x => x.AcPlId == Dir.AcPlId)) { return false; }
            if (!unit.TeacherLoadsViews.OnExist(x => x.AcPlId == Dir.AcPlId)) { return false; }

            //var tmp_check = unit.BlockRecs.GetMany(x => x.AcPlId == Dir.AcPlId);
            //if (!tmp_check.Any()) { return false; }

            var dataLoads = unit.TeacherLoadsViews.GetManyAsync(x => x.DirId == dir_id && x.EFormId == 1).Result.ToList();

            if(dataLoads.Count() < 300) { this.isFull = false; return false; }

            var groupData = dataLoads.GroupBy(x => x.EmpId).ToList();

            var teachList = groupData.Select(x => x.Key);

            var dataRates = unit.TeacherRates.GetManyAsync(x => teachList.Contains(x.EmpId)).Result;
            var dataEDs = unit.TeacherSuitabilities.GetManyAsync(x => teachList.Contains(x.EmpId)).Result;
            var dataRecs = unit.BlockRecs.GetManyAsync(x => x.AcPlId == Dir.AcPlId).Result;

            var groupList = unit.Groups.GetManyAsync(x => x.DirId == dir_id).Result.Select(x => x.GroupId).ToList();

            this.TotalCount = unit.AttAcPlans.GetManyAsync(x => groupList.Contains(x.GroupId.Value)).Result.Count();

            List<exTeacher> exList = new List<exTeacher>();

            foreach (var item in groupData)
            {
                exTeacher exT = new exTeacher();
                exT.Subs = new List<exSubject>();

                var item2 = item.ToList().GroupBy(x => x.SubId);
                var rate = dataRates.FirstOrDefault(x => x.EmpId == item.Key);
                var eDoc = dataEDs.FirstOrDefault(x => x.EmpId == item.Key);

                exT.DegId = eDoc != null ? eDoc.DegId : 1;
                exT.RankId = eDoc != null ? eDoc.RankId : 1;
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


            this.items = unit.TeacherLoadSuitabilities.GetMany(x => x.DirId == dir_id);
            this.exList = exList;

            return true;
        }
    }
}
