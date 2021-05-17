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
using hod_back.Models;

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
    [Route("teachers")]
    public class TeacherController : Controller
    {
        private UnitOfWork _unit;
        private IMapper _mapper;
        private IHostingEnvironment _hostEnv;

        public TeacherController(UnitOfWork unit, IMapper mapper, IHostingEnvironment hostEnv)
        {
            this._unit = unit;
            this._mapper = mapper;
            this._hostEnv = hostEnv;
        }

        [Authorize(Roles = "препод,завед,админ")]
        [HttpGet("get/correspond/{dep_id}")]
        public IEnumerable<GroupTeacherDto> GetCorrespond([FromRoute] int dep_id)
        {
            var tmp = _unit.TeacherDeps.GetMany(x => x.DepId == dep_id);

            var tmp1 = _mapper.Map<IEnumerable<TeacherDepDto>>(tmp).OrderBy(x => x.LastName);

            var groupTmp1 = from i in tmp1
                            group i by i.LastName[0].ToString();

            List<GroupTeacherDto> res = new List<GroupTeacherDto>();
            foreach (IGrouping<string, TeacherDepDto> g in groupTmp1)
            {
                //foreach(var i in g)
                //    i.
                var list = new List<TeacherDepDto>();
                foreach (var j in g)
                    list.Add(j);

                res.Add(new GroupTeacherDto() { letter = g.Key.ToString(), teachers = list.ToArray() });

            }

            return res;
        }

        [Authorize(Roles = "препод,завед,админ")]
        [HttpPost("post/on/att-ac-plan/{attAcPl_id}")]
        public LoadPartDto PostSubmitTeacher([FromRoute] int attAcPl_id, AttAcPlanTeacherModel model)
        {
            if (model.attAcPlan_id == null || model.fsh_id == null)
            {
                return null;
            }
            var tmp = this._unit.AttAcPlans.GetOrDefault(x => x.AttAcPlId == attAcPl_id);
            tmp.FshId = model.fsh_id;
            this._unit.AttAcPlans.Update(tmp);

            var res = new LoadPartDto()
            {
                Fsh_id = model.fsh_id,
                TeacherName = model.teacherName
            };

            return res;
        }

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
