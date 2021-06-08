using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using hod_back.Services.Auth;
using Microsoft.IdentityModel.Tokens;

using hod_back.DAL;
using Microsoft.AspNetCore.Authorization;

namespace hod_back.Controllers
{
    /// <summary>
    /// Контроллер отвечающий за авторизацию пользователей
    /// </summary>
    public class AccountController : Controller
    {
        private UnitOfWork _unit;

        public AccountController(UnitOfWork unit)
        {
            this._unit = unit;
        }

        //[Authorize]
        [HttpGet("/check-token")]
        public IActionResult CheckToken()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BadRequest("Ошибка 403: Неавторизированный пользователь.");
            }

            var now = DateTime.UtcNow;

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: User.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                username = User.Identity.Name,
                access_role_id = User.Claims.ToList()[1].Value,
                access_role = User.Claims.ToList()[2].Value,
                dep_id = User.Claims.ToList()[3].Value,
                dep = User.Claims.ToList()[4].Value,
                access_token = encodedJwt
            };

            return Json(response);
        }

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
                return BadRequest(new { errorText = "Неправильно введен логин или пароль." });
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

            //var response = new
            //{
            //    username = identity.Name,
            //    access_role_id = identity.Claims.ToList()[1].Value,
            //    access_role = identity.Claims.ToList()[2].Value,
            //    id_department = identity.Claims.ToList()[3].Value,
            //    name_department = identity.Claims.ToList()[4].Value,
            //    dateExpired = now,
            //    access_token = encodedJwt
            //};

            var response = new
            {
                username = identity.Name,
                access_role_id = identity.Claims.ToList()[1].Value,
                access_role = identity.Claims.ToList()[2].Value,
                dep_id = identity.Claims.ToList()[3].Value,
                dep_name = identity.Claims.ToList()[4].Value,
                dateExpired = now,
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
            var person = _unit.AuthUsers.GetOrDefaultAsync(x => x.UserLogin == username && x.UserPassword == password).Result;

            if (person == null) { return null; } 

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserLogin),

                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.IdRoleActual.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.NameRoleActual),

                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.DepId.ToString()),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.DepShortname.ToString())
                };

            var claimsIdentity = new ClaimsIdentity(claims,
                                                    "Token",
                                                    ClaimsIdentity.DefaultNameClaimType,
                                                    ClaimsIdentity.DefaultRoleClaimType
                                                    );

            return claimsIdentity;

        }


    }
}
