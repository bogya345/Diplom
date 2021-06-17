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
using hod_back.Extentions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using hod_back.Services.Analyse;

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

        public IEnumerable<DirectionDto> well(int dep_id)
        {
            List<int> list = new List<int>() { 11016, 21017, 21020, 21021, 31020, 31021, 31022, 31023, 31024, 31025, 31026 };
            var res = _unit.Directions.GetManyAsync(x => list.Contains(x.DirId)).Result.Select(x => new DirectionDto()
            {
                Dep_id = x.DepId,
                Dir_id = x.DirId,
                Dir_name = x.EBr.EBrName,
                AcPl_id = x.AcPlId,
                StartYear = x.StartYear,
                Highlight = x.HighlightNum(_unit),
                Status_pps = x.GetDirStatusPPS(x.DirId, _unit, dep_id),
                Status = x.GetDirStatus(x.DirId, _unit, dep_id),
                Requirs = _unit.DirRequirs.GetManyAsync(y => y.DirId == x.DirId).Result.Select(z => new DirRequirDto()
                {
                    Fgos_num = z.FgosNum,
                    SettedValue = z.SettedValue,
                    Unit_name = z.UnitName
                }).ToArray(),
                Groups = _unit.DirGroups.GetManyAsync(y => y.DirId == x.DirId).Result.Select(z => new GroupDto()
                {
                    Group_id = z.GroupId,
                    Group_name = z.GroupName,
                    CreatedDate = z.DateCreate.Value.Year.ToString(),
                    ExitDate = z.DateExit.Value.Year.ToString()
                    //group_acPlan_id = z.AcPlId
                }).ToArray()
            });

            foreach (var i in res)
            {
                if ((i.Status.Status_up != i.Status.Status_down) || i.Status.Status_down == 0)
                {
                    i.Highlight = -1;
                    continue;
                }
            }
            return res;
        }

        [Authorize(Roles = "препод,завед,админ")]
        [AllowAnonymous]
        [HttpGet("get/all/{dep_id}")]
        public IEnumerable<DirectionDto> GetAllDirs([FromRoute] int dep_id)
        {
            //if(dep_id == 3)
            //{

            //}

            List<int> list = new List<int>() { 11016, 21017, 21020, 21021, 31020, 31021, 31022, 31023, 31024, 31025, 31026 };
            var res = _unit.Directions.GetManyAsync(x => list.Contains(x.DirId)).Result.Select(x => new DirectionDto()
            {
                Dep_id = x.DepId,
                Dir_id = x.DirId,
                Dir_name = x.EBr.EBrName,
                AcPl_id = x.AcPlId,
                StartYear = x.StartYear,
                Highlight = x.HighlightNum(_unit),
                Status_pps = x.GetDirStatusPPS(x.DirId, _unit, dep_id),
                Status = x.GetDirStatus(x.DirId, _unit, dep_id),
                Requirs = _unit.DirRequirs.GetManyAsync(y => y.DirId == x.DirId).Result.Select(z => new DirRequirDto()
                {
                    Fgos_num = z.FgosNum,
                    SettedValue = z.SettedValue,
                    Unit_name = z.UnitName
                }).ToArray(),
                Groups = _unit.DirGroups.GetManyAsync(y => y.DirId == x.DirId).Result.Select(z => new GroupDto()
                {
                    Group_id = z.GroupId,
                    Group_name = z.GroupName,
                    CreatedDate = z.DateCreate.Value.Year.ToString(),
                    ExitDate = z.DateExit.Value.Year.ToString()
                    //group_acPlan_id = z.AcPlId
                }).ToArray()
            });

            foreach (var i in res)
            {
                if (i.Status == null) { i.Status = new Status() { Status_down = 0, Status_up = 0 }; i.Highlight = -1; continue; }
                if ((i.Status.Status_up != i.Status.Status_down) || i.Status.Status_down == 0)
                {
                    i.Highlight = -1;
                    continue;
                }
            }

            return res;
        }

        List<int> dirsPropReady = new List<int>() { 21017 };
        public string getPrepared(int dir_id)
        {
            //return @"D:\Unic\Diplom\diploms\hod-back\_Resources\Export\Кадровая справка направления №21017.xlsx";
            switch (dir_id)
            {
                case 21017: { return @$"_Resources\Export\Кадровая справка направления №{dir_id}.xlsx"; }
            }
            return null;
        }

        /// <summary>
        /// кадровая справка по направлению
        /// </summary>
        /// <param name="dir_id"></param>
        /// <returns></returns>
        [Authorize(Roles = "препод,завед,админ")]
        [HttpGet("get/property-doc/{dir_id}")]
        public async Task<CommonResponseDto> GetPropertyDoc([FromRoute] int dir_id)
        {
            if (dirsPropReady.Contains(dir_id))
            {
                await Task.Delay(600);
                var kek = this.getPrepared(dir_id);
                if (kek != null) { return new CommonResponseDto(true, kek, "Кадровая справка."); ; }
            }

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
