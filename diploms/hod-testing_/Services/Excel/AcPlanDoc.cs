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
    public class AcPlanDoc
    {

        private UnitOfWork unit = new UnitOfWork();
        private int dep_id = 1;
        private int dir_id = 152;

        public string path { get; set; } // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Plan_IST_-_16.xlsx"

        private string patternPath { get; set; } = @"D:\Unic\Diplom\@_test_docs\bogya\PlanIST16.xlsx";
        //private string patternPath { get; set; } = @"D:\Unic\Diplom\@_test_docs\bogya\PlanIST16_2.xlsx";

        [TestMethod]
        public void TestMethod1()
        {
            byte[] docBuf;
            using (FileStream fs = new FileStream(patternPath, FileMode.Open, FileAccess.Read))
            {
                docBuf = ReadFully(fs);
            }

            unit.DepDirFac.GetOrDefault(x => x.DepId == dep_id && x.DirId == dir_id);

            Excel ex = new Excel(
                patternPath,
                dep_id,
                dir_id,
                unit,
                docBuf
                );
            // 'D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\ExcelPattern_Property.xlsx'."
            int a = 1;
            ex.Parse();

        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }
}
