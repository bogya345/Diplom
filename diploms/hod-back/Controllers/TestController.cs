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

namespace hod_back.Controllers
{
    [ApiController]
    [Route("testing")]
    public class TestController : Controller
    {

        //public UnitOfWork unit = new UnitOfWork();


        [HttpGet("/test")]
        public string GetConnect_new()
        {
            Context context = new Context();
            var tmp = context.Employees.Take(10);
            return "Ok";
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
