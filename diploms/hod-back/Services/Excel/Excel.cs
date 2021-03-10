using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClosedXML.Excel;
using System.IO;

using hod_back.DAL;
using hod_back.DAL.Models;
using hod_back.DAL.Models.Dictionaries;
using hod_back.DAL.Models.ToParse;
              
namespace hod_back.Services.Excel
{
    public class Excel
    {
        private UnitOfWork unit;
        private Groups group;

        public string path { get; set; }

        public List<Blocks> blocks { get; set; }
        public List<string> subs { get; set; }

        public Excel(string path, string id_group, UnitOfWork unit)
        {
            this.path = path; // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Plan_IST_-_16.xlsx"

            this.unit = unit;

            this.group = this.unit.Groups.Get(int.Parse(id_group));
            if (this.group == null)
            {
                throw new Exception();
            }

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

            //header
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

            subs = new List<string>();
            //subs
            foreach (var row in rows)
            {
                string value = row.Cell(1).Value.ToString();

                if (value.ToLower().Contains("блок") | value.ToLower().Contains("фтд"))
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
                            subs.Add(row.Cell(3).Value.ToString());

                            unit.Subjects.Create(new Subjects { NAME = sub });
                        }
                    }
                }
            }
            unit.Save();

            IgnoreList.Reset();

            int blocknum = 0;

            string blockName = "";
            //block
            foreach (var row in rows)
            {
                string value = row.Cell(1).Value.ToString();

                if (value.ToLower().Contains("блок") | value.ToLower().Contains("фтд"))
                {
                    blocknum = 0;
                    blockName = value;
                    blocks.Add(new Blocks { Name = value, recs = new List<BlockRecs>() });
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

                if ((value == "-" || value == "+") && blocks.Count != 0)
                {
                    if (true)
                    {
                        for (int semIndex = 0; semIndex < semest.Count; semIndex++)
                        {
                            string sub = row.Cell(3).Value.ToString() ?? "";   //subject
                            if (sub != "" && sub != null)
                            {
                                if (!IgnoreList.ignoreList.Any(x => sub.ToLower().Contains(x)))
                                {
                                    blocks.Last().recs.Add(
                                        new BlockRecs(
                                            group.id_group.ToString(),    // id_group
                                            (semIndex + 1).ToString(), // semestr
                                            value,   // InPlan
                                            //getData.FindSubjectIDWithAdding(sub).ToString(),   // subject
                                            unit.Subjects.GetAll().Where(x => x.NAME == sub).FirstOrDefault().ID.ToString(),   // subject
                                            blockName,    // blockNum
                                            row.Cell(semest[semIndex].Column).Value.ToString() ?? "",
                                            row.Cell(semest[semIndex].Column + 1).Value.ToString().Replace(".", ",") ?? "",
                                            row.Cell(semest[semIndex].Column + 2).Value.ToString().Replace(".", ",") ?? "",
                                            row.Cell(semest[semIndex].Column + 3).Value.ToString().Replace(".", ",") ?? "",
                                            row.Cell(semest[semIndex].Column + 4).Value.ToString().Replace(".", ",") ?? "",
                                            row.Cell(semest[semIndex].Column + 5).Value.ToString().Replace(".", ",") ?? "",
                                            row.Cell(semest[semIndex].Column + 6).Value.ToString().Replace(".", ",") ?? "",
                                            row.Cell(semest[semIndex].Column + 7).Value.ToString().Replace(".", ",") ?? "",
                                            row.Cell(semest[semIndex].Column + 8).Value.ToString().Replace(".", ",") ?? "",
                                            row.Cell(semest[semIndex].Column + 9).Value.ToString().Replace(".", ",") ?? ""
                                            )
                                        );
                                }
                            }

                            if (blocks.Last().recs.Count != 0 && blocks.Last().recs.Last().IsEmpty)
                            {
                                blocks.Last().recs.Remove(blocks.Last().recs.Last());
                            }
                        }
                    }
                }
            }

            return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            return false;
        }


    }
}
