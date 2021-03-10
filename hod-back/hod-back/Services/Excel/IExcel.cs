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

namespace hod_.DALback.Services.Excel
{
    public abstract class IExcel
    {
        //private UnitOfWork unit;
        //private Groups group;

        //public string path { get; set; }

        //public IExcel(string path, string id_group, UnitOfWork unit)
        //{
        //    this.path = path; // @"D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\Plan_IST_-_16.xlsx"

        //    this.unit = unit;

        //    this.group = this.unit.Groups.Get(int.Parse(id_group));
        //    if (this.group == null)
        //    {
        //        throw new Exception();
        //    }

        //}

        //abstract 
    }
}
