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
    [Route("acplans")]
    public class AcPlanController : Controller
    {
        private UnitOfWork _unit;
        private IMapper _mapper;
        private IHostingEnvironment _hostEnv;

        public AcPlanController(UnitOfWork unit, IMapper mapper, IHostingEnvironment hostEnv)
        {
            this._unit = unit;
            this._mapper = mapper;
            this._hostEnv = hostEnv;
        }

        /// <summary>
        /// Загрузка документа учебного плана
        /// </summary>
        /// <param name="id_group">ID группы</param>
        /// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        [HttpPost("post/{dep_id}/{dir_id}"), DisableRequestSizeLimit]
        public JsonResult UploadFile(int dep_id, int dir_id)
        {
            //try
            //{

            if (_unit.DepDirFac.GetOrDefault(x => x.DepId == dep_id && x.DirId == dir_id).AcPlId != null) return Json("The plan has already been uploaded.");

            var file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = _hostEnv.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            string fileName = "";

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string fullPath = Path.Combine(newPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            byte[] docBuf;
            using (FileStream fs = new FileStream($"{newPath}/{fileName}", FileMode.Open, FileAccess.Read))
            {
                docBuf = ReadFully(fs);
            }

            Excel ex = new Excel($"{newPath}/{fileName}", dep_id, dir_id, _unit, docBuf);

            if (!ex.Parse()) return Json("Ошибка при обработке документа учебного плана.");
            else
            //{ _unit.AttachedAcPlan.Create(ex.blocks); }
            {
                //foreach (Blocks item in ex.blocks)
                //{
                //    foreach (BlockRecs item2 in item.recs)
                //    {
                //        unit.BlockRecs.Create(item2);

                //        unit.Save();

                //        if (item2.les != 0)
                //        {
                //            unit.TeacherLoads.Create(new TeacherLoad
                //            {
                //                id_blockRec = item2.id_blockRec,
                //                typeSubject = "Лек",
                //                id_employee = null,
                //                hours = item2.les
                //            });
                //        }

                //        if (item2.lab != 0)
                //        {
                //            unit.TeacherLoads.Create(new TeacherLoad
                //            {
                //                id_blockRec = item2.id_blockRec,
                //                typeSubject = "Лаб",
                //                id_employee = null,
                //                hours = item2.lab
                //            });
                //        }

                //        if (item2.pr != 0)
                //        {
                //            unit.TeacherLoads.Create(new TeacherLoad
                //            {
                //                id_blockRec = item2.id_blockRec,
                //                typeSubject = "Пр",
                //                id_employee = null,
                //                hours = item2.pr
                //            });
                //        }

                //        if (item2.iz != 0)
                //        {
                //            unit.TeacherLoads.Create(new TeacherLoad
                //            {
                //                id_blockRec = item2.id_blockRec,
                //                typeSubject = "ИЗ",
                //                id_employee = null,
                //                hours = item2.iz
                //            });
                //        }

                //        if (item2.ak != 0)
                //        {
                //            unit.TeacherLoads.Create(new TeacherLoad
                //            {
                //                id_blockRec = item2.id_blockRec,
                //                typeSubject = "АК",
                //                id_employee = null,
                //                hours = item2.ak
                //            });
                //        }

                //        if (item2.kpr != 0)
                //        {
                //            unit.TeacherLoads.Create(new TeacherLoad
                //            {
                //                id_blockRec = item2.id_blockRec,
                //                typeSubject = "КПр",
                //                id_employee = null,
                //                hours = item2.kpr
                //            });
                //        }

                //        if (item2.sr != 0)
                //        {
                //            unit.TeacherLoads.Create(new TeacherLoad
                //            {
                //                id_blockRec = item2.id_blockRec,
                //                typeSubject = "СР",
                //                id_employee = null,
                //                hours = item2.sr
                //            });
                //        }

                //        if (item2.controll != 0)
                //        {
                //            unit.TeacherLoads.Create(new TeacherLoad
                //            {
                //                id_blockRec = item2.id_blockRec,
                //                typeSubject = "Контроль",
                //                id_employee = null,
                //                hours = item2.controll
                //            });
                //        }

                //        unit.Save();
                //    }
                //}

            }

            return Json("Upload Successful.");
            //}
            //catch (System.Exception ex)
            //{
            //    return Json("Upload Failed: " + ex.Message);
            //}
        }

        public byte[] ReadFully(Stream input)
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
