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
using Microsoft.AspNetCore.Http;
using hod_back.Models;
using Microsoft.Extensions.Configuration;

using hod_back.Extentions;

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
        private IConfiguration _config;

        public AcPlanController(UnitOfWork unit, IMapper mapper, IHostingEnvironment hostEnv, IConfiguration config)
        {
            this._unit = unit;
            this._mapper = mapper;
            this._hostEnv = hostEnv;
            this._config = config;
        }

        [HttpGet("get/subDep")]
        public async Task<IEnumerable<SubDepDto>> GetSubDep()
        {
            var tmp = _unit.Subjects.GetManyWithInclude(x => x.SubId > 0)
                //.ToList()
                ;

            var res = _mapper.Map<IEnumerable<SubDepDto>>(tmp);
            return res;
        }

        [HttpPost("test/{dep_id}/{dir_id}/{group_id}"), DisableRequestSizeLimit]
        public async Task<string> Test([FromRoute] int dep_id, [FromRoute] int dir_id, [FromRoute] int group_id)
        {
            var formCollection = await Request.ReadFormAsync();
            //var file_t = formCollection.Files.First();

            return "nahuo";
        }

        [HttpGet("/weatherforecast"), DisableRequestSizeLimit]
        public async Task<object> Test2([FromRoute] int dep_id, [FromRoute] int dir_id, [FromRoute] int group_id)
        {
            var tmp = _unit.Subjects.GetManyWithInclude(x => x.AcPlDepId > 0)
                //.ToList()
                ;

            var res = _mapper.Map<IEnumerable<SubDepDto>>(tmp);
            return res;
        }

        [HttpPost("post/promote/{attAcPl_id}")]
        public async Task<AttAcPlanDto> PostPromotedTeacher([FromRoute] int attAcPl_id, [FromForm] int fsh_id)
        {
            var tmp = _unit.AttAcPlans.GetOrDefault(x => x.AttAcPlId == attAcPl_id);
            tmp.FshId = fsh_id;
            _unit.AttAcPlans.Update(tmp);

            var res = _mapper.Map<AttAcPlanDto>(tmp);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acPl_id"></param>
        /// <param name="group_id"></param>
        /// <returns>Дисциплины по группе</returns>
        [HttpGet("get/{acPl_id}/{group_id}")]
        public async Task<BlockNumDto[]> GetFullAttAcPlan([FromRoute] int acPl_id, [FromRoute] int group_id)
        {
            var tmp = _unit.BlockNums.GetManyWithInclude(x => x.BlockNumId != 0).ToList();

            var res = from i in tmp
                      select new BlockNumDto()
                      {
                          BlockNumId = i.BlockNumId,
                          BlockName = i.BlockNumName,
                          Subjects = i.BlockRecs.TransformToSubjectDtoArray(acPl_id, group_id)
                      };

            return res.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acPl_id">ID Учебного плана</param>
        /// <param name="group_id">ID группы</param>
        /// <param name="dep_id">ID кафедры</param>
        /// <returns>Множество соответствующих (по кафедре) дисциплины по группе</returns>
        [HttpGet("get/{acPl_id}/{group_id}/correspond/{dep_id}")]
        public async Task<BlockNumDto[]> GetCorrespondAttAcPlan([FromRoute] int acPl_id, [FromRoute] int group_id, [FromRoute] int dep_id)
        {
            var tmp = _unit.BlockNums.GetManyWithInclude(x => x.BlockNumId != 0).ToList();

            var res = from i in tmp
                      select new BlockNumDto()
                      {
                          BlockNumId = i.BlockNumId,
                          BlockName = i.BlockNumName,
                          Subjects = i.BlockRecs.TransformToSubjectDtoArray(acPl_id, group_id)
                      };

            return res.ToArray();
        }

        /// <summary>
        /// Загрузка документа учебного плана
        /// </summary>
        /// <param name="id_group">ID группы</param>
        /// <returns></returns>
        //[Authorize(Roles = "Преподаватель,Заведующий,Админ")]
        //[Produces("application/json")]
        [HttpPost("post/{dep_id}/{dir_id}")]
        [DisableRequestSizeLimit]
        public async Task<JsonResult> UploadFile([FromRoute] int dep_id, [FromRoute] int dir_id, [FromForm] AcPlanModel model)
        {
            //try
            //{

            if (model.file == null)
                return Json("LOX");

            if (model.message == "loxNO")
                return Json("ok-ok");

            //if (_unit.DepDirFac.GetOrDefault(x => x.DepId == dep_id && x.DirId == dir_id).AcPlId != null) return Json("The plan has already been uploaded.");

            var formCollection = await Request.ReadFormAsync();
            var file_t = formCollection.Files.First();

            //if (!Request.ContentType.Contains("json"))
            //{
            //    //return Json("Files not found.");
            //    return"Files not found.";
            //}

            if (Request.Form == null || Request.Form.Files.Count == 0)
            {
                return Json("Files not found.");
                //return "Files not found.";
            }

            var file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = _config.GetSection("WebRootPath").Value.ToString();
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

            _unit.DepDirFac.GetOrDefault(x => x.DepId == dep_id && x.DirId == dir_id);

            Excel ex = new Excel(
                $"{newPath}/{fileName}",
                dep_id,
                dir_id,
                _unit,
                docBuf
                );
            // 'D:\Unic\Diploma\project\HeadOfDepartment\HeadOfDepartment\wwwroot\Upload\ExcelPattern_Property.xlsx'."
            int a = 1;

            if (!ex.Parse())
            {
                return Json("Ошибка при обработке документа учебного плана.");
                //return "Ошибка при обработке документа учебного плана.";
            }
            else
            //{ _unit.AttachedAcPlan.Create(ex.blocks); }
            {
                // проверка на добавление в таблицу нагрузки (AttachedAcPlan)

                // создание нагрузки
                InsertAttAcPlanRecords(ex);
            }

            System.IO.File.Delete($"{newPath}/{fileName}");

            return Json("Upload Successful.");
            //return "Upload Successful.";
            //}
            //catch (System.Exception ex)
            //{
            //    return Json("Upload Failed: " + ex.Message);
            //}
        }

        /// <summary>
        /// Привязка групп к планам направлений
        /// </summary>
        /// <param name="ex"></param>
        private void InsertAttAcPlanRecords(Excel ex)
        {
            /// так как в TRIGGER низя делать вставку нескольких полей, то приходиться делать это через сервер
        }

        private byte[] ReadFully(Stream input)
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
