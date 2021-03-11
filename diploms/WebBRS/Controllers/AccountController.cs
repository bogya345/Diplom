using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBRS.Services.Auth;
using WebBRS.Models;
using WebBRS.Models.Views;
using WebBRS.DAL;

namespace WebBRS.Controllers
{
	public class AccountController : Controller
    {
        UnitOfWork unit = new UnitOfWork();

        /// <summary>
        /// Выдает JWT-token
        /// </summary>
        /// <param name="username">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>username + роль + JWT-token</returns>
        [HttpPost("/token")]
        public IActionResult Token([FromForm] string username, [FromForm] string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                username = identity.Name,
                access_role_id = identity.Claims.ToList()[1].Value,
                access_role = identity.Claims.ToList()[2].Value,
                id_department = identity.Claims.ToList()[3].Value,
                name_department = identity.Claims.ToList()[4].Value,
                access_token = encodedJwt
            };

            return Json(response);
        }

        /// <summary>
        /// Проверка данных
        /// </summary>
        /// <param name="username">логин</param>
        /// <returns></returns>
        private ClaimsIdentity GetIdentity(string username, string password)
        {
            AuthUsers person = null;
            //if (!DAL.DAL_Settings.localAccess)
            //{
            //    // server
            //    //person = people_.FirstOrDefault(x => x.Login == username && x.Password == password);
            //    person = unit.AuthUsers.Get(x => x.email == username && x.password == password);
            //}
            //else
            //{
            //    // local

            //    person = LocalStorage.authusers.FirstOrDefault(x => x.email == username && x.password == password);

            //    //// если пользователя не найдено
            //    //if (person == null) { throw new Exception(); return null; }

            //    //person.email = LocalStorage.authusers.First(x => x.id_employee == person.id_employee).login;

            //    //person.name_role = LocalStorage.roles.Where(y => y.id_role == person.id_role).ToList()
            //    //        .Aggregate((a, b) => a.id_role > b.id_role ? a : b).name_role;
            //}

            if (person == null) { throw new Exception(); } // проверить целостность данных пользователей

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.email),

                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.id_role_actual.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.name_role_actual),

                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.id_department.ToString()),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.name_department.ToString())
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                                                                "Token",
                                                                ClaimsIdentity.DefaultNameClaimType,
                                                                ClaimsIdentity.DefaultRoleClaimType
                                                                );

            return claimsIdentity;

        }
    }
}
