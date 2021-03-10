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

using hod_back.DAL.Models;
using hod_back.DAL.Models.Views;
using hod_back.DAL.Models.ToRecieve;
using hod_back.DAL.Models.ToSend;
using hod_back.DAL.Models.ToParse;

using hod_back.DAL;
using hod_back.DAL.Contexts;

using hod_back.Services.Excel;

namespace hod_back.Controllers
{
    [ApiController]
    [Route("cathedra")]
    public class CathedraController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();

        public CathedraController()
        {

        }

        [HttpGet("test")]
        public string test()
        {
            return "cathedra controller";
        }

        /// <summary>
        /// Все кафедры
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        [HttpGet("getall")]
        public IEnumerable<CathInfo> GetCathedra()
        {
            try
            {
                List<CathInfo> tmp = unit.CathInfo.GetAll().ToList();
                return tmp;
                //return unit.CathInfo.GetAll();
            }
            catch (Exception ex)
            {
                return LocalStorage.cathinfo.ToList();
            }
        }

        [Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        [HttpGet("{id_cathedra}/groups")]
        public IEnumerable<Groups> GetGroups(string id_cathedra)
        {
            try
            {
                return unit.Groups.GetAll(x => x.id_department == int.Parse(id_cathedra));
            }
            catch (Exception ex)
            {
                return LocalStorage.groups.Where(x => x.id_department == int.Parse(id_cathedra));
            }
        }

        /// <summary>
        /// Информация для домашней страницы
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "преподаватель,Заведующий,Админ")]
        [HttpGet("info")]
        public CathedraInfo GetCathedraInfo()
        {
            string user_dep_id = User.Claims.ToList()[2].Value;
            CathedraInfo result = new CathedraInfo(user_dep_id);
            return result;
        }


        // Route( "/teachers" )
        #region Преподаватели

        /// <summary>
        /// Получение списка преподавателей
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        [HttpGet("teachers/getall")]
        public IEnumerable<Employees> GetAllTeachers()
        {

            // idk how it make better but...
            //List<Teachers_toSend> list = new List<Teachers_toSend>();
            //foreach (TeacherCathedra item in unit.TeachersCathedras.GetAll().ToList())
            //{
            //    TeacherCathedra_toSend result = new TeacherCathedra_toSend(unit.context, item);
            //    list.Add(result);
            //}

            return unit.Employees.GetAllTeachers().ToList();

        }

        /// <summary>
        /// Отправка списка 1наченных преподавателей по группе
        /// </summary>
        /// <param name="id_group">ID группы</param>
        /// <returns></returns> - getviewteacherload/{id_group}
        [Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        [HttpGet("teachers/load/{id_group}")]
        public IEnumerable<ViewTeacherLoad> GetViewTeacherLoad(string id_group)
        {
            int id_group_ = Convert.ToInt32(id_group);

            if (!DAL_Settings.localAccess)
            {
                // idk how it make better
                List<ViewTeacherLoad> list_ = unit.ViewTeacherLoads.GetAll(x => x.id_group == id_group_).ToList();
                return list_;
            }
            else
            {
                List<ViewTeacherLoad> list_ = LocalStorage.viewsteachload.Where(x => x.id_group == id_group_).ToList();
                return list_;
            }
        }

        /// <summary>
        /// Назначение преподователей
        /// </summary>
        /// <param name="data">Данные для назначения (список назначенных преподователей)</param>
        /// <returns></returns> -- updateteachersload
        [Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        [HttpPost("teachers/promotion")]
        public JsonResult PromoteTeacher([FromBody] List<TeachersLoad_toRecieve> data)
        {

            foreach (TeachersLoad_toRecieve item in data)
            {
                TeacherLoad tmp = new TeacherLoad
                {
                    id_blockRec = item.blockRec,
                    typeSubject = item.typeSubject,
                    id_employee = item.id_teacherCath
                };

                unit.TeacherLoads.Update(tmp);
            }

            unit.Save();

            return Json("Teacher has been promoted");
        }

        #endregion

    }
}
