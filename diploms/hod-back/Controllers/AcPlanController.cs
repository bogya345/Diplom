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

        [HttpGet("get/{dir_id}")]
        public CommonResponseDto GetAcPlan([FromRoute] int dir_id)
        {
            var dir = _unit.Directions.GetOrDefaultWithInclude(x => x.DirId == dir_id);

            if (dir == null) { return new CommonResponseDto("Направление не найдено."); }
            if (dir.AcPlId == null) { return new CommonResponseDto("Учебный план не найден."); }
            if (dir.AcPl.Document == null) { return new CommonResponseDto("Документ не был найден, пожулайста, обратитесь к администратору."); }

            string folderName = "Export";
            string webRootPath = _config.GetSection("WebRootPath").Value.ToString();
            string newPath = Path.Combine(webRootPath, folderName);

            string fileName = newPath + @$"\Учебный план №{dir_id}.xlsx";

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            try
            {
                byte[] byteArray = dir.AcPl.Document;
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return new CommonResponseDto(true, fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return new CommonResponseDto("Ошибка. Не удалось скачать файл.");
            }
        }

        [HttpPost("post/subDep")]
        public JsonResult PostSubDep([FromForm] IEnumerable<SubDepModel> model)
        {
            var tmp = _mapper.Map<IEnumerable<AcPlanDep>>(model);

            _unit.AcPlanDeps.UpdateRange(tmp.ToArray());

            return Json("Изменения сохранены");
        }

        [HttpGet("get/subDep")]
        public async Task<IEnumerable<SubDepDto>> GetSubDep()
        {
            var tmp = _unit.Subjects.GetManyWithIncludeAsync(x => x.SubId > 0)
                 //.ToList()
                 ;

            var res = _mapper.Map<IEnumerable<SubDepDto>>(tmp.Result);
            return res;
        }

        [HttpPost("test/{dep_id}/{dir_id}/{group_id}"), DisableRequestSizeLimit]
        public string Test([FromRoute] int dep_id, [FromRoute] int dir_id, [FromRoute] int group_id)
        {
            //var formCollection = Request.ReadFormAsync();
            //var file_t = formCollection.Files.First();

            return "nahuo";
        }

        [HttpGet("/weatherforecast"), DisableRequestSizeLimit]
        public async Task<object> Test2([FromRoute] int dep_id, [FromRoute] int dir_id, [FromRoute] int group_id)
        {
            var tmp = _unit.Subjects.GetManyWithIncludeAsync(x => x.SubId > 0)
                 //.ToList()
                 ;

            var res = _mapper.Map<IEnumerable<SubDepDto>>(tmp.Result);
            return res;
        }

        [HttpPost("post/promote/{attAcPl_id}")]
        public AttAcPlanDto PostPromotedTeacher([FromRoute] int attAcPl_id, [FromForm] int fsh_id)
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
            var tmp = (await _unit.BlockNums.GetManyWithIncludeAsync(x => x.BlockNumId != 0)).ToList();
            //var tmp2 = _unit.TeacherDeps.GetOrDefault(x => x.)

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
            var tmp = (await _unit.BlockNums.GetManyWithIncludeAsync(x => x.BlockNumId != 0)).ToList();

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
            //return Json("Test");

            //try
            //{

            if (model.file == null)
                return Json("LOX");

            if (model.message == "loxNO")
                return Json("ok-ok");

            //if (_unit.DepDirFac.GetOrDefault(x => x.DepId == dep_id && x.DirId == dir_id).AcPlId != null) return Json("The plan has already been uploaded.");

            //var formCollection = Request.();
            //var file_t = formCollection.Files.First();

            //if (!Request.ContentType.Contains("json"))
            //{
            //    //return Json("Files not found.");
            //    return"Files not found.";
            //}

            if (model.file == null || Request.Form.Files.Count == 0)
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
            //int a = 1;

            if (!ex.Parse())
            //if (!ex.Count() != 0)
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
        private async void InsertAttAcPlanRecords(Excel ex)
        {
            /// так как в TRIGGER низя делать вставку нескольких полей, то приходиться делать это через сервер
            /// 
            _unit.BlockRecs.CreateRangeAsync(ex.accumRecs.ToArray());
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
