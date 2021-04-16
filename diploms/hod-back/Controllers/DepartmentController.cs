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

//using hod_back.DAL.Models;
//using hod_back.DAL.Models.Views;
//using hod_back.DAL.Models.ToRecieve;
//using hod_back.DAL.Models.ToSend;
//using hod_back.DAL.Models.ToParse;

//using hod_back.DAL;
//using hod_back.DAL.Contexts;

//using hod_back.Services.Excel;

namespace hod_back.Controllers
{
    [ApiController]
    [Route("deps")]
    public class DepartmentController : Controller
    {
        private UnitOfWork _unit;
        private IMapper _mapper;
        private IHostingEnvironment _hostEnv;

        public DepartmentController(UnitOfWork unit, IMapper mapper, IHostingEnvironment hostEnv)
        {
            this._unit = unit;
            this._mapper = mapper;
            this._hostEnv = hostEnv;
        }

        /// <summary>
        /// Получить все кафедры с информацией
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ,Уму")]
        [HttpGet("info")]
        public async Task<IEnumerable<DepsInfoDto>> GetCathedra()
        {
            var t = Request.Headers;
            return _mapper.Map<IEnumerable<DepsInfo>, IEnumerable<DepsInfoDto>>(_unit.DepsInfo.GetAll());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get/all")]
        public async Task<IEnumerable<DepsDto>> GetAllDeps()
        {
            var tmp = _unit.Departments.GetAll();
            var res = _mapper.Map<IEnumerable<DepsDto>>(tmp);
            return res;
        }

        /// <summary>
        /// получить все кафедры
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "преподаватель,заведующий,админ,уму")]
        [HttpGet("getall/dirfac")]
        public async Task<IEnumerable<DepsDto>> GetDeps()
        {
            var tmp = _unit.DepDirFac.GetAll().ToList();

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
                           dep_id = dep.Key.DepId,
                           dep_name = dep.Key.DepName,
                           dirs = tmp.Where(x => x.DepId == dep.Key.DepId).Select(x => new DirectionDto()
                           {
                               dir_id = x.DirId,
                               dir_name = x.EBrName,
                               acPl_id = x.AcPlId,
                               requirs = _unit.DirRequirs.GetMany(y => y.DirId == x.DirId).Select(z => new DirRequirDto()
                               {
                                   fgos_num = z.FgosNum,
                                   settedValue = z.SettedValue,
                                   unit_name = z.UnitName
                               }).ToArray(),
                               groups = _unit.DirGroups.GetMany(y => y.DirId == x.DirId).Select(z => new GroupDto()
                               {
                                   group_id = z.GroupId,
                                   group_name = z.GroupName,
                                   //group_acPlan_id = z.AcPlId
                               }).ToArray()

                           }).ToArray()
                       };

            return tmp2;
        }

        /// <summary>
        /// получить кафедру по id
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "преподаватель,заведующий,админ,уму")]
        [HttpGet("get/{dep_id}")]
        public async Task<DepsDto> GetCurDep(int dep_id)
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
                           dep_id = dep.Key.DepId,
                           dep_name = dep.Key.DepName,
                           dirs = tmp.Where(x => x.DepId == dep.Key.DepId).Select(x => new DirectionDto()
                           {
                               dir_id = x.DirId,
                               dir_name = x.EBrName,
                               acPl_id = x.AcPlId,
                               requirs = _unit.DirRequirs.GetMany(y => y.DirId == x.DirId).Select(z => new DirRequirDto()
                               {
                                   fgos_num = z.FgosNum,
                                   settedValue = z.SettedValue,
                                   unit_name = z.UnitName
                               }).ToArray(),
                               groups = _unit.DirGroups.GetMany(y => y.DirId == x.DirId).Select(z => new GroupDto()
                               {
                                   group_id = z.GroupId,
                                   group_name = z.GroupName,
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
