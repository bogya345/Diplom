using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ClosedXML.Excel;
using System.IO;

using hod_back.DAL;
using hod_back.Model;
using hod_back.misc;

//using hod_back.DAL.Models.Views;
//using hod_back.DAL.Models.Dictionaries;
//using hod_back.DAL.Models.ToParse;

namespace hod_back.Services.Excel
{
    public class Excel_Load
    {
        private UnitOfWork unit;

        public string path { get; set; } // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Plan_IST_-_16.xlsx"

        private string patternPath { get; set; } = @"D:\Unic\Diplom\diploms\hod-back\_Resources\Patterns\ExcelPattern_Loads.xlsx";

        private string accessPath { get; set; } = @$"\Кафедральная нагрузка";

        private int dep_id { get; set; }
        private Department Dep { get; set; }



        public Excel_Load(string path, int dep_id, UnitOfWork unit)
        {
            this.unit = unit;

            this.path = path;

            this.dep_id = dep_id;
            this.Dep = unit.Departments.GetOrDefaultAsync(x => x.DepId == dep_id).Result;
        }

        public string CreateTempFile()
        {
            //string path = this.accessPath + $"{Dep.DepShortname}.xlsx";
            return this.path;
        }

        public string CreateAndFillTempFile()
        {
            var wb = new XLWorkbook(this.patternPath);
            var ws = wb.Worksheet(1);

            var data = unit.DepartmentLoads.GetManyAsync(x => x.DepId == this.dep_id).Result.OrderBy(x => x.SemestrNum).ThenBy(x => x.SubName);

            var groupData = data.GroupBy(x => new { x.EmpId, x.GroupId, x.SemestrNum, x.SubId });

            // заголовок
            ws.Cell("A" + 2).Value = this.Dep.DepName;

            int activeRow = 4;
            foreach (var i in groupData)
            {
                ws.Cell("A" + activeRow).Value = i.ToList()[0].SubName;
                ws.Cell("B" + activeRow).Value = i.ToList()[0].GroupName;
                ws.Cell("C" + activeRow).Value = i.ToList()[0].SemestrNum;

                ws.Cell("D" + activeRow).Value = i.ToList().FirstOrDefault(x => x.SubTId == 1) != null ? i.ToList().FirstOrDefault(x => x.SubTId == 1).HourValue : 0;
                ws.Cell("E" + activeRow).Value = i.ToList().FirstOrDefault(x => x.SubTId == 3) != null ? i.ToList().FirstOrDefault(x => x.SubTId == 3).HourValue : 0;
                ws.Cell("F" + activeRow).Value = i.ToList().FirstOrDefault(x => x.SubTId == 2) != null ? i.ToList().FirstOrDefault(x => x.SubTId == 2).HourValue : 0;

                if (i.ToList().FirstOrDefault(x => x.SubTId == 7) != null)
                {
                    ws.Cell("G" + activeRow).Value = "-";
                    ws.Cell("H" + activeRow).Value = "+";
                }
                else
                {
                    ws.Cell("G" + activeRow).Value = "+";
                    ws.Cell("H" + activeRow).Value = "-";
                }

                ws.Cell("I" + activeRow).Value = i.ToList()[0].FullName;

                ws.Row(activeRow).InsertRowsBelow(1);
                activeRow++;
            }

            wb.SaveAs(this.path);
            return this.path;
        }

    }
}
