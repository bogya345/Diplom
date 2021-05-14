using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClosedXML.Excel;
using System.IO;

using hod_back.Model;
using hod_back.DAL;
using hod_back.DAL.Models.ToParse;
using AutoMapper;
using hod_back.Profiles;

using hod_back.Extentions;

namespace hod_back.Services.Excel
{
    public class Excel
    {
        private UnitOfWork unit;

        private readonly List<AcPlanDep> acPlanDeps;

        private readonly Department dep;
        private readonly Direction dir;
        private readonly AcPlan acPl;

        private List<BlockNum> blockNums;
        public List<BlockRec> recs;

        private bool isNewAcPl;

        public List<BlockRec> accumRecs;

        //private IMapper _mapper;

        public string path { get; set; }

        public List<Blocks> blocks { get; set; }

        public Excel(string path, int dep_id, int dir_id, UnitOfWork unit, byte[] docAcPlan)
        {
            this.path = path; // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Plan_IST_-_16.xlsx"

            this.unit = unit;

            this.acPlanDeps = unit.AcPlanDeps.GetAll().ToList();

            this.dep = unit.Departments.GetOrDefault(x => x.DepId == dep_id);// new Department { DepId = dep_id }

            this.dir = unit.Directions.GetOrDefault(x => x.DirId == dir_id); // ?? new Direction() { DirId = dir_id }

            this.acPl = dir.AcPlId != null
                ? unit.AcPlans.GetOrDefault(x => x.AcPlId == dir.AcPlId) : new AcPlan { Document = docAcPlan };
            this.isNewAcPl = dir.AcPlId == null;

            this.blockNums = unit.BlockNums.GetAll().ToList();


            if (!this.isNewAcPl)
            {
                this.recs = unit.BlockRecs.GetMany(x => x.AcPlId == this.dir.AcPlId).ToList();
            }

            if (this.isNewAcPl)
            {
                unit.AcPlans.CreateWithReturn(this.acPl);
                this.dir.AcPlId = this.acPl.AcPlId;
                unit.Directions.Update(this.dir);
            }
            else
            {
                unit.AcPlans.Update(acPl);
            }

            this.accumRecs = new List<BlockRec>();

            //this._mapper = new Mapper(new MapperConfiguration(c =>
            //{
            //    c.AddProfile(new BlockRecsProfile());
            //}));
            //this.dir = unit.DepDirFac.
        }

        private static class IgnoreList
        {
            private static List<string> ignoreBlock1List = new List<string> { "дисциплины", "выбору" }; // дисциплины по выбору
            private static List<string> ignoreBlock2List = new List<string> { "учебная практика", "производственная практика" };

            public static List<string> ignoreList;
            private static int i = 0;

            public static void Next()
            {
                switch (i)
                {
                    case 0:
                        ignoreList = ignoreBlock1List;
                        break;
                    case 1:
                        ignoreList = ignoreBlock2List;
                        break;
                    default:
                        i = 0;
                        return;
                }
                i++;
            }

            public static void Reset() { i = 0; }
        }



        public bool Parse()
        {

            //try
            //{

            List<ExCell> semest = new List<ExCell>();

            var wb = new XLWorkbook(path);
            var worksheet = wb.Worksheet(1);

            var rows = worksheet.RangeUsed().RowsUsed();

            // Заголовок учебного плана
            foreach (var row in rows)
            {
                foreach (var cell in row.Cells())
                {
                    string val = cell.Value.ToString();
                    if (!val.ToLower().Contains("сем"))
                    {
                        continue;
                    }
                    else
                    {
                        try
                        {
                            int sem = int.Parse(val.ToLower().Last().ToString());
                            semest.Add(new ExCell(cell.Address.ColumnNumber, cell.Address.RowNumber, cell.Address.ColumnLetter));
                        }
                        catch (Exception e) { throw new Exception(); }
                    }

                    if (val.Contains("код"))
                    {
                        break;
                    }
                }
            }


            #region Дисциплины

            List<Subject> buf_subs = unit.Subjects.GetAll().ToList();
            List<Subject> subs_new = new List<Subject>();
            // Дисциплины
            foreach (var row in rows)
            {
                string value = row.Cell(1).Value.ToString();

                if (value.ToLower().Contains("блок") || value.ToLower().Contains("фтд"))
                {
                    IgnoreList.Next();
                }

                if (IgnoreList.ignoreList != null)
                {
                    string sub = row.Cell(3).Value.ToString() ?? "";    //subject
                    if (sub != "")
                    {
                        if (!IgnoreList.ignoreList.Any(x => sub.ToLower().Contains(x)))
                        {
                            if (buf_subs.FirstOrDefault(x => string.Equals(x.SubName, sub, StringComparison.InvariantCultureIgnoreCase)) == null)
                            {
                                Subject sub_ = new Subject();
                                sub_.SubName = sub;

                                string dep_uid = row.Cell("CW").Value.ToString();   //dep uid
                                string dep_name = row.Cell("CX").Value.ToString();  //dep name

                                var tmp = this.acPlanDeps.FirstOrDefault(x => string.Equals(x.AcPlDepName, dep_name, StringComparison.InvariantCultureIgnoreCase));
                                if (tmp == null)
                                {
                                    var tmp_acPlDep = new AcPlanDep()
                                    {
                                        AcPlDepId = Convert.ToInt32(dep_uid),
                                        AcPlDepName = dep_name
                                    };

                                    unit.AcPlanDeps.Create(tmp_acPlDep);
                                    this.acPlanDeps.Add(tmp_acPlDep);

                                    sub_.AcPlDepId = tmp_acPlDep.AcPlDepId;
                                }
                                else
                                {
                                    sub_.AcPlDepId = tmp.AcPlDepId;
                                }

                                buf_subs.Add(sub_);
                                subs_new.Add(sub_);
                            }
                        }
                    }
                }
            }
            #endregion

            // 
            if (subs_new.Count != 0) { unit.Subjects.CreateRange(subs_new.ToArray()); unit.Save(); }

            IgnoreList.Reset();


            #region Блоки

            //List<BlockNum> buf_bNums = new List<BlockNum>();
            //List<BlockNum> blockNums = unit.BlockNums.GetAll();

            List<BlockRec> buf_bRecs = new List<BlockRec>();

            int blocknum = 0;
            string blockName = "";
            int bNumId = -1;

            // Блоки
            foreach (var row in rows)
            {
                string value = row.Cell(1).Value.ToString();

                if (
                    value.Contains("блок", StringComparison.InvariantCultureIgnoreCase) ||
                    value.Contains("фтд", StringComparison.InvariantCultureIgnoreCase)
                   )
                {
                    blocknum = 0;
                    blockName = value;
                    BlockNum curBlockNum = blockNums.FirstOrDefault(x => string.Equals(x.BlockNumName, blockName));

                    if (curBlockNum == null)
                    {
                        curBlockNum = new BlockNum { BlockNumName = value };

                        curBlockNum = unit.BlockNums.CreateWithReturn(curBlockNum);
                        blockNums.Add(curBlockNum);
                    }

                    bNumId = curBlockNum.BlockNumId;

                    IgnoreList.Next();
                    foreach (char ch in value)
                    {
                        if (Char.IsDigit(ch))
                        {
                            blocknum = int.Parse(ch.ToString());
                            break;
                        }
                    }
                }

                if ((value == "-" || value == "+") && bNumId != -1)
                {
                    if (true)
                    {
                        for (int semIndex = 0; semIndex < semest.Count; semIndex++)
                        {
                            string sub = row.Cell(3).Value.ToString() ?? "";   //subject
                            if (sub != "")
                            {
                                if (!IgnoreList.ignoreList.Any(x => sub.ToLower().Contains(x)))
                                {
                                    ExCell tmp = semest[semIndex];

                                    string ze_ = row.Cell(semest[semIndex].Column).Value.ToString().Replace('.', ',');
                                    float? ze =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(ze_)
                                            ? "0" : ze_); //итого

                                    string total_ = row.Cell(semest[semIndex].Column + 1).Value.ToString().Replace('.', ',');
                                    float? total =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(total_)
                                            ? "0" : total_); //итого

                                    string les_ = row.Cell(semest[semIndex].Column + 2).Value.ToString().Replace('.', ',');
                                    float? les =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(les_)
                                            ? "0" : les_); //лек

                                    string lab_ = row.Cell(semest[semIndex].Column + 3).Value.ToString().Replace('.', ',');
                                    float? lab =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(lab_)
                                            ? "0" : lab_); //лаб

                                    string pr_ = row.Cell(semest[semIndex].Column + 4).Value.ToString().Replace('.', ',');
                                    float? pr =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(pr_)
                                            ? "0" : pr_); //пр

                                    string iz_ = row.Cell(semest[semIndex].Column + 5).Value.ToString().Replace('.', ',');
                                    float? iz =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(iz_)
                                            ? "0" : iz_); //из

                                    string ak_ = row.Cell(semest[semIndex].Column + 6).Value.ToString().Replace('.', ',');
                                    float? ak =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(ak_)
                                            ? "0" : ak_); //ак

                                    string kpr_ = row.Cell(semest[semIndex].Column + 7).Value.ToString().Replace('.', ',');
                                    float? kpr =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(kpr_)
                                            ? "0" : kpr_); //кпр

                                    string sr_ = row.Cell(semest[semIndex].Column + 8).Value.ToString().Replace('.', ',');
                                    float? sr =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(sr_)
                                            ? "0" : sr_); //ср

                                    string control_ = row.Cell(semest[semIndex].Column + 9).Value.ToString().Replace('.', ',');
                                    float? control =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(control_)
                                            ? "0" : control_); //контроль


                                    int subId = unit.Subjects.GetOrDefault(x => string.Equals(sub, x.SubName, StringComparison.InvariantCultureIgnoreCase)).SubId;

                                    buf_bRecs.Add(new BlockRec
                                    {
                                        AcPlId = this.acPl.AcPlId,
                                        SemestrNum = semIndex + 1,
                                        InPlan = value == "+" ? 1 : 0,
                                        SubId = subId,
                                        BlockNumId = bNumId,
                                        Ze = ze,
                                        Total = total,
                                        Les = les,
                                        Lab = lab,
                                        Pr = pr,
                                        Iz = iz,
                                        Ak = ak,
                                        Kpr = kpr,
                                        Sr = sr,
                                        Controll = control,
                                    });

                                }
                            }

                            //if (blocks.Last().recs.Count != 0 && blocks.Last().recs.Last().IsEmpty)
                            //{
                            //    blocks.Last().recs.Remove(blocks.Last().recs.Last());
                            //}
                        }
                    }
                }
            }

            if (this.isNewAcPl)
            {
                //unit.BlockRecs.CreateRange(buf_bRecs.ToArray());
                this.accumRecs = buf_bRecs;
            }
            else UpdateRange(buf_bRecs);

            #endregion


            return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            return false;
        }

        private void UpdateRange(List<BlockRec> items)
        {
            items = items
                .OrderBy(x => x.SubId)
                .ThenBy(x => x.SemestrNum)
                .ToList();

            this.recs = this.recs
                .OrderBy(x => x.SubId)
                .ThenBy(x => x.SemestrNum)
                .ToList();

            List<BlockRec> buf = new List<BlockRec>();
            if (this.recs.Count != 0)
            {
                foreach (BlockRec i in items)
                {
                    int index = i.IsSameSubject(this.recs);
                    if (index != -1)
                    {
                        // значит новых предметов не появилось
                        var t = this.recs[index];
                        this.recs[index].RewriteValues(i);
                    }
                    else
                    {
                        // новый предмет
                        buf.Add(i);
                    }
                }

                if (buf.Count != 0)
                {
                    unit.BlockRecs.CreateRange(buf.ToArray());
                }

                unit.BlockRecs.UpdateRange(this.recs.ToArray());
            }
            else
            {
                unit.BlockRecs.CreateRange(items.ToArray());
            }

            //if (this.recs.Count != 0)
            //{
            //    unit.BlockRecs.DeleteRange(this.recs.ToArray());
            //}
            //unit.BlockRecs.CreateRange(items.ToArray());

            // необходимо будет сделать фиксацию изменения (для дальнейшего уведомления пользователей о изменениях)

        }


    }
}
