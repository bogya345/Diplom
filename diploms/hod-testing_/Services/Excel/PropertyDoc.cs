using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using ClosedXML.Excel;
using System.IO;

using hod_back.Model;
using hod_back.DAL;
using hod_back.Services.Excel;

namespace hod_testing_
{
    [TestClass]
    public class PropertyDoc
    {

        private UnitOfWork unit = new UnitOfWork();
        private int dep_id = 1;
        private int dir_id = 151;
        //private int dir_id = 152;

        public string path { get; set; } // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Plan_IST_-_16.xlsx"

        private string patternPath { get; set; } = @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Patterns\ExcelPattern_Property.xlsx"; // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\ExcelPattern_Property.xlsx"


        [TestMethod]
        public void TestMethod1()
        {

            //Excel_Property ex = new Excel_Property(
            //    @$"D:\Unic\Diplom\diploms\hod-back\_Resources\Export\Кадровая справка {dep_id} {dir_id}.xlsx",
            //    dep_id,
            //    dir_id,
            //    unit
            //    );
            // 'D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\ExcelPattern_Property.xlsx'."

            //ex.CreateAndFillTempFile();

        }
    }
}
