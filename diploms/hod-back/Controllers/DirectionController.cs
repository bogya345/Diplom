using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using hod_back.DAL;
using hod_back.Model;
using AutoMapper;
using hod_back.Dto;
using hod_back.Services.Excel;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace hod_back.Controllers
{
    [ApiController]
    [Route("dirs")]
    public class DirectionController : Controller
    {
        private UnitOfWork _unit;
        private IMapper _mapper;
        private IHostingEnvironment _hostEnv;
        private IConfiguration _config;

        public DirectionController(UnitOfWork unit, IMapper mapper, IHostingEnvironment hostEnv, IConfiguration config)
        {
            this._unit = unit;
            this._mapper = mapper;
            this._hostEnv = hostEnv;
            this._config = config;
        }

        #region region1 comments
        //[HttpGet("get/property-doc/{dir_id}")]
        //public IActionResult GetPropertyDoc([FromRoute] int dir_id)
        //{
        //    string tmp = _hostEnv.WebRootPath;
        //    //"D:\\Unic\\Diploma\\project\\HeadOfDepartment\\HeadOfDepartment\\wwwroot"

        //    var dir = _unit.Directions.GetOrDefaultWithInclude(x => x.DirId == dir_id);

        //    string folderName = "Export";
        //    string webRootPath = _config.GetSection("WebRootPath").Value.ToString();
        //    string newPath = Path.Combine(webRootPath, folderName);

        //    string fileName = "";

        //    if (!Directory.Exists(newPath))
        //    {
        //        Directory.CreateDirectory(newPath);
        //    }

        //    Excel_Property ex = new Excel_Property(newPath + @$"\Кадровая справка направления №{dir_id}.xlsx", dir, _unit);
        //    // 'D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\ExcelPattern_Property.xlsx'."

        //    string path = ex.CreateAndFillTempFile();

        //    StreamReader stream = new StreamReader(path);
        //    if (stream.BaseStream == null) return BadRequest("stream is null");
        //    return File(stream.BaseStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");

        //    //var fileMemoryStream = GenerateReportAndWriteToMemoryStream(...);
        //    //return File(
        //    //    fileMemoryStream,
        //    //    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        //    //    "report.xlsx");
        //}
        #endregion

        #region region2 comments
        //[HttpGet("get/property-doc/{dir_id}")]
        //public IActionResult GetPropertyDoc([FromRoute] int dir_id)
        //{
        //    string tmp = _hostEnv.WebRootPath;
        //    //"D:\\Unic\\Diploma\\project\\HeadOfDepartment\\HeadOfDepartment\\wwwroot"

        //    var dir = _unit.Directions.GetOrDefaultWithInclude(x => x.DirId == dir_id);

        //    string folderName = "Export";
        //    string webRootPath = _config.GetSection("WebRootPath").Value.ToString();
        //    string newPath = Path.Combine(webRootPath, folderName);

        //    string fileName = "";

        //    if (!Directory.Exists(newPath))
        //    {
        //        Directory.CreateDirectory(newPath);
        //    }

        //    Excel_Property ex = new Excel_Property(newPath + @$"\Кадровая справка направления №{dir_id}.xlsx", dir, _unit);
        //    // 'D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\ExcelPattern_Property.xlsx'."

        //    string path = ex.CreateAndFillTempFile();

        //    System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
        //    {
        //        FileName = path,
        //        Inline = false  // false = prompt the user for downloading;  true = browser to try to show the file inline
        //    };
        //    Response.Headers.Add("Content-Disposition", cd.ToString());
        //    Response.Headers.Add("X-Content-Type-Options", "nosniff");

        //    return File(System.IO.File.ReadAllBytes(path), "application/excel");

        //    //StreamReader stream = new StreamReader(path);
        //    ////if (stream.BaseStream == null) return BadRequest("stream is null");
        //    //return File(stream.BaseStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet").FileDownloadName;
        //    //return File(stream.BaseStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");

        //    //var fileMemoryStream = GenerateReportAndWriteToMemoryStream(...);
        //    //return File(
        //    //    fileMemoryStream,
        //    //    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        //    //    "report.xlsx");
        //}
        #endregion

        [Authorize(Roles = "препод,завед,админ")]
        [HttpGet("get/property-doc/{dir_id}")]
        public CommonResponseDto GetPropertyDoc([FromRoute] int dir_id)
        {
            string tmp = _hostEnv.WebRootPath;
            //"D:\\Unic\\Diploma\\project\\HeadOfDepartment\\HeadOfDepartment\\wwwroot"

            var dir = _unit.Directions.GetOrDefaultWithInclude(x => x.DirId == dir_id);

            string folderName = "Export";
            string webRootPath = _config.GetSection("WebRootPath").Value.ToString();
            string newPath = Path.Combine(webRootPath, folderName);

            string fileName = "";

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            Excel_Property ex = new Excel_Property(newPath + @$"\Кадровая справка направления №{dir_id}.xlsx", dir, _unit);
            // 'D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\ExcelPattern_Property.xlsx'."
            var res = ex.CreateAndFillTempFile();

            return new CommonResponseDto(true, res, "Кадровая справка.");
            //return "_Resources/Export/Кадровая справка направления №151.xlsx";
        }

        //public class PropertyDoc
        //{
        //    public string Path { get; set; }
        //}

        ///// <summary>
        ///// Получить все направления по кафедре
        ///// </summary>
        ///// <param name="dep_id">ID кафедры</param>
        ///// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //[HttpGet("directions/{dir_id}/groups")]
        //public IEnumerable<Group> GetGroups(int dep_id)
        //{
        //    var tmp = _unit..GetMany(x => x.DirectId == dep_id);
        //    return tmp;
        //}

    }
}
