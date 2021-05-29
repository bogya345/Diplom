using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebBRS.Models;
using WebBRS.Models.Auth;
using WebBRS.Services.Auth;
using WebBRS.DAL;

namespace WebBRS.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IOptions<AuthOptions> authOptions;
		public AuthController(IOptions<AuthOptions> authOptions)
		{
			this.authOptions = authOptions;
		}
		private UnitOfWork unit = new UnitOfWork();

		//private List<Account> Accounts => new List<Account>
		//{
		//	new Account()
		//	{
		//		Id = Guid.Parse("E5F672BE-F086-E211-B260-0018FE865BEB"),
		//		Email = "user@email.com",
		//		Password = "user",
		//		Roles = new Role[]{Role.User}
		//	},
		//	new Account()
		//	{
		//		Id = Guid.Parse("ECF672BE-F086-E211-B260-0018FE865BEB"),
		//		Email = "user2@email.com",
		//		Password = "user2",
		//		Roles = new Role[]{Role.User}
		//	},
		//	new Account()
		//	{
		//		Id = Guid.Parse("F2F672BE-F086-E211-B260-0018FE865BEB"),
		//		Email = "admin@email.com",
		//		Password = "admin",
		//		Roles = new Role[]{Role.Admin}
		//	}
		//};
		[Route("login")]
		[HttpPost]
		public IActionResult Login([FromBody] Login request)
		{
			var user = AuthenticateUser(request.Email, request.Password);
			if (user != null)
			{
				var token = GenerateJWT(user);
				return Ok(new
				{
					access_token = token,
					role = user.Role.name_role,
					roleId = user.Role.id_role,
					email = user.Email,
				});
				//HttpContext.User.Identity.Name = user.Email;
			}
			return Unauthorized();
		}
		private Account AuthenticateUser(string email, string password)
		{
			Account account = new Account();

			User user =unit.Users.Get(u => u.login == email && u.password == password);
			account.Email = user.login;
			account.Password = user.password;
			//Role role = unit.context.Roles
			account.Role = user.Role;
			return account;
		}
		private string GenerateJWT(Account user)
		{
			var authParams = authOptions.Value;
			var securityKey = AuthOptions.GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())

			};
			claims.Add(new Claim("role", user.Role.name_role));
			claims.Add(new Claim("Name", user.Email));
			//foreach (var role in user.Roles)
			//{
			//}
			var token = new JwtSecurityToken(AuthOptions.ISSUER,
				AuthOptions.AUDIENCE,
				claims,
				expires: DateTime.Now.AddSeconds(AuthOptions.LIFETIME),
				signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
