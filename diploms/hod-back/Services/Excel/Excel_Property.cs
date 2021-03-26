using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClosedXML.Excel;
using System.IO;

using hod_back.DAL;
using hod_back.Model;

using hod_back.DAL.Models.Views;
using hod_back.DAL.Models.Dictionaries;
using hod_back.DAL.Models.ToParse;

namespace hod_back.Services.Excel
{
    public class Excel_Property
    {
        private UnitOfWork unit;
        private Group group;

        public string path { get; set; } // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Plan_IST_-_16.xlsx"

        private string patternPath { get; set; } = @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Patterns\ExcelPattern_Property.xlsx";

        public List<Blocks> blocks { get; set; }
        public List<string> subs { get; set; }

        public Excel_Property(string path, string id_group, UnitOfWork unit)
        {
            this.unit = unit;

            this.group = this.unit.Groups.Get(int.Parse(id_group));
            if (this.group == null)
            {
                throw new Exception();
            }

        }

        public string CreateTempFile()
        {

            //var workbook

            return this.path;
        }

        public string CreateAndFillTempFile()
        {
            var wb = new XLWorkbook(this.patternPath);
            var ws = wb.Worksheet(1);

            //List<ViewTeacherLoad> data = unit.context.ViewTeacherLoad.Where(x => x.id_group == this.group.id_group && x.id_employee != null).ToList();
            List<ViewTeacherLoad> data = null;

            var groupData = data.GroupBy(x => x.id_employee);

            int i = 1;
            //int activeCol = 1;
            int activeRow = 9;
            int secondaryRow = activeRow;

            ws.Cell("A" + 3).Value = "Информационные системы и технологии";
            ws.Cell("A" + 4).Value = "Форма обучения очная, год набора " + "2020";

            foreach (var item in groupData)
            {
                var item2 = item.ToList().GroupBy(x => x.id_subject);

                ws.Cell("A" + activeRow).Value = i;
                ws.Cell("B" + activeRow).Value = item.ToList()[0].name_employee;
                ws.Cell("C" + activeRow).Value = "Штатный";
                ws.Cell("D" + activeRow).Value = "Должность";

                ws.Cell("F" + activeRow).Value = "Уровень образования";
                ws.Cell("G" + activeRow).Value = "Дополнительное образование";

                // disciplines + hours + rate
                secondaryRow = activeRow;
                foreach (var item3 in item2.ToList())
                {
                    // E - дисциплина
                    // J - лекции
                    // K - занатия семинарного типа
                    // L - ИЗ
                    // M - АК
                    // H & N - кол-во часов
                    // I & O - доля ставки

                    foreach (var tmp in item3)
                    {
                        if (tmp.InPlan != 1)
                        {
                            continue;
                        }

                        ws.Cell("E" + secondaryRow).Value = tmp.subject;

                        switch (tmp.typeSubject.ToLower())
                        {
                            case "лек": { ws.Cell("J" + secondaryRow).Value = tmp.hours.ToString(); break; }

                            case "лаб":
                            case "пр":
                                {
                                    if (ws.Cell("K" + secondaryRow).Value == null || ws.Cell("K" + secondaryRow).Value.ToString() == "")
                                    {
                                        ws.Cell("K" + secondaryRow).Value = tmp.hours.ToString();
                                        break;
                                    }
                                    else
                                    {
                                        ws.Cell("K" + secondaryRow).Value = (tmp.hours + Convert.ToDouble(ws.Cell("K" + secondaryRow).Value)).ToString();
                                        break;
                                    }
                                }

                            case "из": { ws.Cell("L" + secondaryRow).Value = tmp.hours.ToString(); break; }
                            case "ак": { ws.Cell("M" + secondaryRow).Value = tmp.hours.ToString(); break; }

                        }

                        //ws.Cell("I" + secondaryRow).Value = "ставка";
                        //ws.Cell("J" + activeRow).Value = unit.BlockRecs.GetAll().Where(y => y.id_blockRec == item3.ToList().Where(x => x.typeSubject.Contains("ИЗ")).First().blockrecs_id_blockRec).FirstOrDefault().les;
                        //ws.Cell("k" + activeRow).Value = unit.BlockRecs.GetAll().Where(y => y.id_blockRec == item3.ToList().Where(x => x.typeSubject.Contains("ИЗ")).First().blockrecs_id_blockRec).FirstOrDefault().les;
                        //ws.Cell("L" + activeRow).Value = ;
                        //ws.Cell("M" + activeRow).Value = ;
                        //ws.Cell("N" + activeRow).Value = ;
                        //ws.Cell("O" + secondaryRow).Value = "ставка";
                    }

                    string countHours = item3.Where(x => x.InPlan == 1
                                                        && x.typeSubject.ToLower() != "контроль"
                                                        && x.typeSubject.ToLower() != "ср")
                                                        .Sum(x => x.hours).ToString();
                    ws.Cell("H" + secondaryRow).Value = countHours;
                    ws.Cell("N" + secondaryRow).Value = countHours;

                    string distictRate = "ставка";
                    ws.Cell("I" + secondaryRow).Value = distictRate;
                    ws.Cell("O" + secondaryRow).Value = distictRate;

                    ws.Row(secondaryRow).InsertRowsBelow(1);
                    secondaryRow++;
                }

                ws.Cell("P" + activeRow).Value = "Причичание";

                //

                ws.Row(secondaryRow).Delete();
                secondaryRow--;

                // merging cells
                ws.Range("A" + activeRow.ToString() + ":A" + secondaryRow.ToString()).Merge();
                ws.Range("B" + activeRow.ToString() + ":B" + secondaryRow.ToString()).Merge();
                ws.Range("C" + activeRow.ToString() + ":C" + secondaryRow.ToString()).Merge();
                ws.Range("D" + activeRow.ToString() + ":D" + secondaryRow.ToString()).Merge();
                ws.Range("F" + activeRow.ToString() + ":F" + secondaryRow.ToString()).Merge();
                ws.Range("G" + activeRow.ToString() + ":G" + secondaryRow.ToString()).Merge();
                ws.Range("P" + activeRow.ToString() + ":P" + secondaryRow.ToString()).Merge();
                //

                activeRow = secondaryRow;

                ws.Row(activeRow).InsertRowsBelow(1);
                activeRow++;
                i++;
            }

            ws.Cell("I" + (activeRow + 1)).Value = "ИТОГ";

            //ws.Visibility = XLWorksheetVisibility.Visible;

            //wb.SaveAs(@"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\toDownload\property.xlsx");
            wb.SaveAs(@"D:\Unic\Diploma\test\property.xlsx");

            return @".\Upload\toDownload\property.xlsx";
        }

    }
}
