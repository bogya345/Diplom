using AutoMapper;
using hod_back.DAL;
using hod_back.Dto;
using hod_back.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using System.IO;
using System;

using hod_back.Services.Excel;
using hod_back.Extentions;

namespace hod_back.Controllers
{
    [ApiController]
    [Route("deps")]
    public class DepartmentController : Controller
    {
        private UnitOfWork _unit;
        private IMapper _mapper;
        private IHostingEnvironment _hostEnv;

        private IConfiguration _config;

        public DepartmentController(UnitOfWork unit, IMapper mapper, IHostingEnvironment hostEnv, IConfiguration config)
        {
            this._unit = unit;
            this._mapper = mapper;
            this._hostEnv = hostEnv;
            this._config = config;
        }

        /// <summary>
        /// Получить нагрузку кафедры
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "препод,завед,админ,уму")]
        [HttpGet("get/load/{dep_id}")]
        public async Task<CommonResponseDto> GetLoad([FromRoute] int dep_id)
        {
            var Dep = await _unit.Departments.GetOrDefaultAsync(x => x.DepId == dep_id);
            if (Dep == null) { return new CommonResponseDto("Такая кафедра не найдена."); }

            string tmp = _hostEnv.WebRootPath;

            string folderName = "Export";
            string webRootPath = _config.GetSection("WebRootPath").Value.ToString();
            string newPath = Path.Combine(webRootPath, folderName);

            string fileName = "";

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            Excel_Load ex = new Excel_Load(newPath + @$"\Кафедральная нагрузка {Dep.DepShortname}.xlsx", dep_id, _unit);
            // 'D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\ExcelPattern_Property.xlsx'."
            var res = ex.CreateAndFillTempFile  ();

            return new CommonResponseDto(true, res, "Кафедральная нагрузка.");
        }

        /// <summary>
        /// Получить все кафедры с информацией
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "препод,завед,админ,уму")]
        [HttpGet("info/{dep_id}")]
        public async Task<DepsInfoDto> GetConcreteCathedra([FromRoute] int dep_id)
        {
            var depInfo = await _unit.DepsInfo.GetOrDefaultAsync(x => x.DepId == dep_id);
            var res = _mapper.Map<DepsInfoDto>(depInfo);
            return res;
        }

        /// <summary>
        /// Получить все кафедры с информацией
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "препод,завед,админ,уму")]
        [HttpGet("info")]
        public async Task<IEnumerable<DepsInfoDto>> GetCathedra()
        {
            var depInfos = await _unit.DepsInfo.GetAllAsync();
            return _mapper.Map<IEnumerable<DepsInfo>, IEnumerable<DepsInfoDto>>(depInfos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get/cathedras/all")]
        public async Task<IEnumerable<DepsDto>> GetAllDeps()
        {
            var tmp = await _unit.Departments.GetManyAsync(x => x.DepTId == 6);
            var res = _mapper.Map<IEnumerable<DepsDto>>(tmp);
            return res;
        }

        /// <summary>
        /// получить все кафедры
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "препод,завед,админ,уму")]
        [HttpGet("getall/dirfac")]
        public async Task<IEnumerable<DepsDto>> GetDeps()
        {
            mark:
            try
            {
                var tmp = await _unit.DepDirFac.GetAllAsync();

                IEnumerable<DepsDto> tmp2 = from i in tmp
                                            group i by new
                                            {
                                                i.DepId,
                                                i.DepGuid,
                                                i.DepName,
                                                i.FacId,
                                                i.FacName
                                            } into dep
                                            select new DepsDto()
                                            {
                                                Dep_id = dep.Key.DepId,
                                                Dep_name = dep.Key.DepName,
                                                Dirs = tmp.Where(x => x.DepId == dep.Key.DepId).Select(x => new DirectionDto()
                                                {
                                                    Dir_id = x.DirId,
                                                    Dir_name = x.EBrName,
                                                    AcPl_id = x.AcPlId,
                                                    StartYear = x.StartYear,
                                                    Status = x.GetDirStatus(x.DirId, _unit),
                                                    //Status_msg // auto

                                                    Requirs = _unit.DirRequirs.GetManyAsync(y => x.DirId == y.DirId).Result.Select(z => new DirRequirDto()
                                                    {
                                                        Fgos_num = z.FgosNum.NewFgos(),
                                                        SettedValue = z.SettedValue,
                                                        Unit_name = z.UnitName
                                                    }).ToArray(),

                                                    //Requirs = _unit.DirRequirs.GetManyAsync(x.DirId).Result != null ? _unit.DirRequirs.GetManyAsync(x.DirId).Result.Select(z => new DirRequirDto()
                                                    //{
                                                    //    Fgos_num = z.FgosNum.NewFgos(),
                                                    //    SettedValue = z.SettedValue,
                                                    //    Unit_name = z.UnitName
                                                    //}).ToArray() : null,

                                                    Groups = _unit.DirGroups.GetMany(y => y.DirId == x.DirId).Select(z => new GroupDto()
                                                    {
                                                        Group_id = z.GroupId,
                                                        Group_name = z.GroupName,
                                                        CreatedDate = z.DateCreate.Value.Year.ToString(),
                                                        ExitDate = z.DateExit.Value.Year.ToString()
                                                        //group_acPlan_id = z.AcPlId
                                                    }).ToArray()

                                                }).ToArray()
                                            };
                return tmp2;
            }
            catch(InvalidOperationException ex)
            {
                await Task.Delay(500);
                goto mark;
            }
        }

        /// <summary>
        /// получить кафедру по id
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "препод,завед,админ,уму")]
        [HttpGet("get/{dep_id}")]
        public DepsDto GetCurDep(int dep_id)
        {
            var tmp = _unit.DepDirFac.GetMany(x => x.DepId == dep_id).ToList();

            var tmp2 = from i in tmp
                       group i by new
                       {
                           i.DepId,
                           i.DepGuid,
                           i.DepName,
                           i.FacId,
                           i.FacName
                       } into dep
                       select new DepsDto()
                       {
                           Dep_id = dep.Key.DepId,
                           Dep_name = dep.Key.DepName,
                           Dirs = tmp.Where(x => x.DepId == dep.Key.DepId).Select(x => new DirectionDto()
                           {
                               Dir_id = x.DirId,
                               Dir_name = x.EBrName,
                               AcPl_id = x.AcPlId,
                               Requirs = _unit.DirRequirs.GetMany(y => y.DirId == x.DirId).Select(z => new DirRequirDto()
                               {
                                   Fgos_num = z.FgosNum,
                                   SettedValue = z.SettedValue,
                                   Unit_name = z.UnitName
                               }).ToArray(),
                               Groups = _unit.DirGroups.GetMany(y => y.DirId == x.DirId).Select(z => new GroupDto()
                               {
                                   Group_id = z.GroupId,
                                   Group_name = z.GroupName,
                                   CreatedDate = z.DateCreate.Value.Year.ToString(),
                                   ExitDate = z.DateExit.Value.Year.ToString()
                                   //group_acPlan_id = z.AcPlId
                               }).ToArray()

                           }).ToArray()
                       };


            return tmp2.First();
        }

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


        //    /// <summary>
        //    /// Информация для домашней страницы
        //    /// </summary>
        //    /// <returns></returns>
        //    [Authorize(Roles = "преподаватель,Заведующий,Админ")]
        //    [HttpGet("info")]po
        //    public CathedraInfo GetCathedraInfo()
        //    {
        //        string user_dep_id = User.Claims.ToList()[2].Value;
        //        CathedraInfo result = new CathedraInfo(user_dep_id);
        //        return result;
        //    }


        //    // Route( "/teachers" )
        //    #region Преподаватели

        //    /// <summary>
        //    /// Получение списка преподавателей
        //    /// </summary>
        //    /// <returns></returns>
        //    [Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //    [HttpGet("teachers/getall")]
        //    public IEnumerable<Employees> GetAllTeachers()
        //    {

        //        // idk how it make better but...
        //        //List<Teachers_toSend> list = new List<Teachers_toSend>();
        //        //foreach (TeacherCathedra item in unit.TeachersCathedras.GetAll().ToList())
        //        //{
        //        //    TeacherCathedra_toSend result = new TeacherCathedra_toSend(unit.context, item);
        //        //    list.Add(result);
        //        //}

        //        return unit.Employees.GetAllTeachers().ToList();

        //    }

        //    /// <summary>
        //    /// Отправка списка 1наченных преподавателей по группе
        //    /// </summary>
        //    /// <param name="id_group">ID группы</param>
        //    /// <returns></returns> - getviewteacherload/{id_group}
        //    [Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //    [HttpGet("teachers/load/{id_group}")]
        //    public IEnumerable<ViewTeacherLoad> GetViewTeacherLoad(string id_group)
        //    {
        //        int id_group_ = Convert.ToInt32(id_group);

        //        if (!DAL_Settings.localAccess)
        //        {
        //            // idk how it make better
        //            List<ViewTeacherLoad> list_ = unit.ViewTeacherLoads.GetMany(x => x.id_group == id_group_).ToList();
        //            return list_;
        //        }
        //        else
        //        {
        //            List<ViewTeacherLoad> list_ = LocalStorage.viewsteachload.Where(x => x.id_group == id_group_).ToList();
        //            return list_;
        //        }
        //    }

        //    /// <summary>
        //    /// Назначение преподователей
        //    /// </summary>
        //    /// <param name="data">Данные для назначения (список назначенных преподователей)</param>
        //    /// <returns></returns> -- updateteachersload
        //    [Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //    [HttpPost("teachers/promotion")]
        //    public JsonResult PromoteTeacher([FromBody] List<TeachersLoad_toRecieve> data)
        //    {

        //        foreach (TeachersLoad_toRecieve item in data)
        //        {
        //            TeacherLoad tmp = new TeacherLoad
        //            {
        //                id_blockRec = item.blockRec,
        //                typeSubject = item.typeSubject,
        //                id_employee = item.id_teacherCath
        //            };

        //            unit.TeacherLoads.Update(tmp);
        //        }

        //        unit.Save();

        //        return Json("Teacher has been promoted");
        //    }

        //    #endregion

    }
}
