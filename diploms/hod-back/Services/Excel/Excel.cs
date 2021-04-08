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

namespace hod_back.Services.Excel
{
    public class Excel
    {
        private UnitOfWork unit;

        private Direction dir;
        private AcPlan acPl;
        private Department dep;
        private bool isNewAcPl;

        private IMapper _mapper;

        public string path { get; set; }

        public List<Blocks> blocks { get; set; }

        public Excel(string path, int dep_id, int dir_id, UnitOfWork unit, byte[] docAcPlan)
        {
            this.path = path; // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Plan_IST_-_16.xlsx"

            this.unit = unit;


            this.dep = unit.Departments.GetOrDefault(x => x.DepId == dep_id);// new Department { DepId = dep_id }

            this.dir = unit.Directions.GetOrDefault(x => x.DirId == dir_id); // ?? new Direction() { DirId = dir_id }

            this.acPl = dir.AcPlId != null 
                ? unit.AcPlans.GetOrDefault(x => x.AcPlId == dir.AcPlId) : new AcPlan { Document = docAcPlan };
            this.isNewAcPl = dir.AcPlId == null;

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

            this._mapper = new Mapper(new MapperConfiguration(c =>
            {
                c.AddProfile(new BlockRecsProfile());
            }));

            //this.dir = unit.DepDirFac.

        }

        private static class IgnoreList
        {
            private static List<string> ignoreBlock1List = new List<string> { "дисциплины", "по", "выбору", "-" };
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
            blocks = new List<Blocks>();

            //List<SubjectRecord> blocks = new List<SubjectRecord>();

            List<int> blockcount = new List<int>();

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
                        catch (Exception e) { }
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
                    string sub = row.Cell(3).Value.ToString() ?? "";   //subject
                    if (sub != "")
                    {
                        if (!IgnoreList.ignoreList.Any(x => sub.ToLower().Contains(x)))
                        {
                            if (buf_subs.FirstOrDefault(x => string.Equals(x.SubName, sub, StringComparison.InvariantCultureIgnoreCase)) == null)
                            {
                                buf_subs.Add(new Subject { SubName = sub });
                                subs_new.Add(new Subject { SubName = sub });
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

            List<BlockNum> buf_bNums = new List<BlockNum>();
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

                    if (buf_bNums.FirstOrDefault(x => string.Equals(x.BlockNumName, value)) == null)
                    {
                        BlockNum bNum = new BlockNum { BlockNumName = value };

                        bNum = unit.BlockNums.CreateWithReturn(bNum);
                        buf_bNums.Add(bNum);
                        
                        bNumId = bNum.BlockNumId;
                    }
                    
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

                if ((value == "-" || value == "+") && buf_bNums.Count != 0)
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

                                    float? ze =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //итого

                                    float? total =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column + 1).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //итого

                                    float? les =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column + 2).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //лек

                                    float? lab =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column + 3).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //лаб

                                    float? pr =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column + 4).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //пр

                                    float? iz =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column + 5).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //из

                                    float? ak =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column + 6).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //ак

                                    float? kpr =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column + 7).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //кпр

                                    float? sr =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column + 8).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //ср

                                    float? control =
                                        (float?)Convert.ToDouble(
                                            string.IsNullOrWhiteSpace(row.Cell(semest[semIndex].Column + 9).Value.ToString())
                                            ? 0 : row.Cell(semest[semIndex].Column + 1).Value); //контроль

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

                                    //buf_bRecs.Add(new BlockRec
                                    //{
                                    //    BlockNumId = buf_bNums.Last().BlockNumId,
                                    //    AcPlId = 
                                    //}
                                    //);
                                    //blocks.Last().recs.Add(
                                    //    new BlockRec {
                                    //        dir dir.DirId,    // id_group
                                    //        (semIndex + 1).ToString(), // semestr
                                    //        value,   // InPlan
                                    //                 //getData.FindSubjectIDWithAdding(sub).ToString(),   // subject
                                    //        unit.Subjects.GetAll().Where(x => x.SubName == sub).FirstOrDefault().SubId.ToString(),   // subject
                                    //        blockName,    // blockNum
                                    //        row.Cell(semest[semIndex].Column).Value.ToString() ?? "",
                                    //        row.Cell(semest[semIndex].Column + 1).Value.ToString().Replace(".", ",") ?? "",
                                    //        row.Cell(semest[semIndex].Column + 2).Value.ToString().Replace(".", ",") ?? "",
                                    //        row.Cell(semest[semIndex].Column + 3).Value.ToString().Replace(".", ",") ?? "",
                                    //        row.Cell(semest[semIndex].Column + 4).Value.ToString().Replace(".", ",") ?? "",
                                    //        row.Cell(semest[semIndex].Column + 5).Value.ToString().Replace(".", ",") ?? "",
                                    //        row.Cell(semest[semIndex].Column + 6).Value.ToString().Replace(".", ",") ?? "",
                                    //        row.Cell(semest[semIndex].Column + 7).Value.ToString().Replace(".", ",") ?? "",
                                    //        row.Cell(semest[semIndex].Column + 8).Value.ToString().Replace(".", ",") ?? "",
                                    //        row.Cell(semest[semIndex].Column + 9).Value.ToString().Replace(".", ",") ?? ""
                                    //        }
                                    //    );
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

            if (this.isNewAcPl) unit.BlockRecs.CreateRange(buf_bRecs.ToArray());
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
            List<BlockRec> buf = unit.BlockRecs.GetMany(x => x.AcPlId == this.acPl.AcPlId)
                .OrderBy(x => x.SemestrNum)
                .ThenBy(x => x.SubId)
                .ToList();
            items = items
                .OrderBy(x => x.SemestrNum)
                .ThenBy(x => x.SubId)
                .ToList();

            var tmp = _mapper.Map(buf, items);

            //unit.BlockRecs.UpdateRande(tmp.ToArray());
        }


    }
}
