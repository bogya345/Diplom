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
using AutoMapper;
using hod_back.Dto;

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
    [Produces("application/json")]
    [Route("groups")]
    public class GroupController : Controller
    {
        private UnitOfWork _unit;
        private IMapper _mapper;

        public GroupController(UnitOfWork unit, IMapper mapper)
        {
            this._unit = unit;
            this._mapper = mapper;
        }

        /// <summary>
        /// Получить записи учебного плана по группе
        /// </summary>
        /// <param name="dir_id">ID направления</param>
        /// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ")]s
        [HttpGet("get/plan/{group_id}")]
        public IEnumerable<AcPlanDto> GetAcPlan(int group_id)
        {
            List<AcPlanDto> tmp = null;
            return tmp;
        }

        ///// <summary>
        ///// Получить все группы по направлению
        ///// </summary>
        ///// <param name="dir_id">ID направления</param>
        ///// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //[HttpGet("direction/{dir_id}/groups")]
        //public IEnumerable<Group> GetGroups(int dir_id)
        //{
        //    var tmp = _unit.Groups.GetMany(x => x.DirectId == dir_id);
        //    return tmp;
        //}

        ////public 

        ///// <summary>
        ///// Добавление новой группы
        ///// </summary>
        ///// <param name="data">Данные для создания группы</param>
        ///// <returns></returns>
        //[Authorize(Roles = "Админ")]
        //[HttpPost("addgroup")]
        //public JsonResult AddGroup([FromBody] Groups_toRecieve data)
        //{

        //    //goto skip;

        //    Groups tmp = new Groups
        //    {
        //        id_department = 1,
        //        id_educForm = 1,
        //        id_qualification = 1,
        //        name_group = data.name_group,
        //        startYear = new DateTime(int.Parse(data.startYear), 9, 1)
        //    };

        //    unit.Groups.Create(tmp);
        //    unit.Save();

        //skip:

        //    return Json("nice");
        //}

        ///// <summary>
        ///// </summary>
        ///// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //[HttpGet("get_groups")]
        //public ClassGetProperty GetClassGetProperty()
        //{
        //    var t = new ClassGetProperty(unit, Convert.ToInt32(User.Claims.ToList()[2].Value));
        //    return (ClassGetProperty)t;
        //}

        ///// <summary>
        ///// Данные учебной загрузки для показа в таблице
        ///// </summary>
        ///// <param name="id_group">ID группы</param>
        ///// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //[HttpGet("getgroupssubjects/{id_group}")]
        //public IEnumerable<BlockRecs_toSend> GetBlockRecs_toSend(string id_group)
        //{
        //    List<BlockRecs_toSend> list = new List<BlockRecs_toSend>();
        //    int id_group_ = Convert.ToInt32(id_group);

        //    // WARNING (LOOPS) - but idk how to make it better
        //    foreach (BlockRecs item in unit.BlockRecs.GetMany(x => x.id_group == id_group_).ToList())
        //    {
        //        BlockRecs_toSend result = new BlockRecs_toSend(unit, item);
        //        list.Add(result);
        //    }

        //    return list.OrderBy(x => x.semestrNum).ThenBy(x => x.subject).ToList();
        //}


        //#region Учебный план и кадровая справка

        ///// <summary>
        ///// Экспорт кадровой справки
        ///// </summary>
        ///// <param name="id_group">ID группы</param>
        ///// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //[HttpGet("property/getdocproperty/{id_group}")]
        //public string ReadyPropertyDoc(string id_group)
        //{
        //    string tmp = _hostingEnvironment.WebRootPath;
        //    //"D:\\Unic\\Diploma\\project\\HeadOfDepartment\\HeadOfDepartment\\wwwroot"

        //    Excel_Property ex = new Excel_Property(_hostingEnvironment.WebRootPath + @"\Upload\Plan_IST_-_16.xlsx", id_group, unit);
        //    // 'D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\ExcelPattern_Property.xlsx'."

        //    return ex.CreateAndFillTempFile();
        //}

        ///// <summary>
        ///// Загрузка документа учебного плана
        ///// </summary>
        ///// <param name="id_group">ID группы</param>
        ///// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //[HttpPost("property/{id_group}"), DisableRequestSizeLimit]
        //public JsonResult UploadFile(string id_group)
        //{
        //    //try
        //    //{

        //    if (unit.BlockRecs.GetAll().Where(x => x.id_group == int.Parse(id_group)).FirstOrDefault() != null)
        //    {
        //        return Json("The plan has already been uploaded.");
        //    }

        //    if (id_group == null)
        //    {
        //        return Json("Kek.");
        //    }

        //    var file = Request.Form.Files[0];
        //    string folderName = "Upload";
        //    string webRootPath = _hostingEnvironment.WebRootPath;
        //    string newPath = Path.Combine(webRootPath, folderName);

        //    string fileName = "";

        //    if (!Directory.Exists(newPath))
        //    {
        //        Directory.CreateDirectory(newPath);
        //    }
        //    if (file.Length > 0)
        //    {
        //        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //        string fullPath = Path.Combine(newPath, fileName);
        //        using (var stream = new FileStream(fullPath, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //    }

        //    Excel ex = new Excel($"{newPath}/{fileName}", id_group, unit);

        //    if (ex.Parse())
        //    {
        //        foreach (Blocks item in ex.blocks)
        //        {
        //            foreach (BlockRecs item2 in item.recs)
        //            {
        //                unit.BlockRecs.Create(item2);

        //                unit.Save();

        //                if (item2.les != 0)
        //                {
        //                    unit.TeacherLoads.Create(new TeacherLoad
        //                    {
        //                        id_blockRec = item2.id_blockRec,
        //                        typeSubject = "Лек",
        //                        id_employee = null,
        //                        hours = item2.les
        //                    });
        //                }

        //                if (item2.lab != 0)
        //                {
        //                    unit.TeacherLoads.Create(new TeacherLoad
        //                    {
        //                        id_blockRec = item2.id_blockRec,
        //                        typeSubject = "Лаб",
        //                        id_employee = null,
        //                        hours = item2.lab
        //                    });
        //                }

        //                if (item2.pr != 0)
        //                {
        //                    unit.TeacherLoads.Create(new TeacherLoad
        //                    {
        //                        id_blockRec = item2.id_blockRec,
        //                        typeSubject = "Пр",
        //                        id_employee = null,
        //                        hours = item2.pr
        //                    });
        //                }

        //                if (item2.iz != 0)
        //                {
        //                    unit.TeacherLoads.Create(new TeacherLoad
        //                    {
        //                        id_blockRec = item2.id_blockRec,
        //                        typeSubject = "ИЗ",
        //                        id_employee = null,
        //                        hours = item2.iz
        //                    });
        //                }

        //                if (item2.ak != 0)
        //                {
        //                    unit.TeacherLoads.Create(new TeacherLoad
        //                    {
        //                        id_blockRec = item2.id_blockRec,
        //                        typeSubject = "АК",
        //                        id_employee = null,
        //                        hours = item2.ak
        //                    });
        //                }

        //                if (item2.kpr != 0)
        //                {
        //                    unit.TeacherLoads.Create(new TeacherLoad
        //                    {
        //                        id_blockRec = item2.id_blockRec,
        //                        typeSubject = "КПр",
        //                        id_employee = null,
        //                        hours = item2.kpr
        //                    });
        //                }

        //                if (item2.sr != 0)
        //                {
        //                    unit.TeacherLoads.Create(new TeacherLoad
        //                    {
        //                        id_blockRec = item2.id_blockRec,
        //                        typeSubject = "СР",
        //                        id_employee = null,
        //                        hours = item2.sr
        //                    });
        //                }

        //                if (item2.controll != 0)
        //                {
        //                    unit.TeacherLoads.Create(new TeacherLoad
        //                    {
        //                        id_blockRec = item2.id_blockRec,
        //                        typeSubject = "Контроль",
        //                        id_employee = null,
        //                        hours = item2.controll
        //                    });
        //                }

        //                unit.Save();
        //            }
        //        }

        //    }

        //    return Json("Upload Successful.");
        //    //}
        //    //catch (System.Exception ex)
        //    //{
        //    //    return Json("Upload Failed: " + ex.Message);
        //    //}
        //}

        //#endregion

    }
}
