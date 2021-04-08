using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//using hod_back.DAL.Models;
//using hod_back.Model;
//using hod_back.DAL.Models.Dictionaries;
//using hod_back.DAL.Models.ToSend;
//using hod_back.DAL.Models.ToRecieve;
//using hod_back.DAL.Models.Views;
//using hod_back.DAL;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using hod_back.Services.Auth;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

using hod_back.Model;
using hod_back.DAL;
using AutoMapper;
using hod_back.Dto;

namespace hod_back.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : Controller
    {

        //public UnitOfWork unit = new UnitOfWork();

        private UnitOfWork _unit;
        private IMapper _mapper;

        public TestController(UnitOfWork unit, IMapper mapper)
        {
            this._unit = unit;
            this._mapper = mapper;
        }

        [HttpGet("/test")]
        public string GetConnect_new()
        {
            Context context = new Context();
            var tmp = context.Employees.Take(10).ToList();
            return $"OK = {tmp[0].FirstName}";
        }

        [HttpGet("/depsinfo")]
        public string GetDepsInfo()
        {
            var tmp = _unit.DepsInfo.GetAll().ToList();
            return $"OK = {tmp[0].FirstName}";
        }

        [HttpGet("/deps")]
        public async Task<IEnumerable<DepsDto>> GetDeps()
        {
            var tmp = _unit.DepDirFac.GetAll().ToList();

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
                               }).ToArray()

                           }).ToArray()
                       };

            return tmp2;
        }

        //[HttpGet("/open")]
        //public IEnumerable<Groups> GetConnect()
        //{
        //    return unit.Groups.GetMany(x => x.id_group == 1 || x.id_group == 2 || x.id_group == 3);
        //}

        //[Authorize]
        //[HttpGet("getlogin")]
        //public IActionResult GetLogin()
        //{
        //    return Ok($"Ваш логин: {User.Identity.Name}");
        //}

        //[Authorize(Roles = "Преподаватель,Заведующий,Уму,Админ")]
        //[HttpGet("getroles1")]
        //public IActionResult GetRoles1()
        //{
        //    return Ok($"Ваша роль: {User.Claims.ToList()[3].Value}");
        //}

        //[Authorize(Roles = "Заведующий")]
        //[HttpGet("getroles2")]
        //public IActionResult GetRoles2()
        //{
        //    return Ok($"Ваша роль: kek");
        //}


        //[Authorize(Roles = "admin")]
        //[HttpGet("getrole")]
        //public IActionResult GetRole()
        //{
        //    return Ok("Ваша роль: администратор");
        //}

    }
}
