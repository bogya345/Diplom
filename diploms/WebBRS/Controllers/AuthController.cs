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
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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
		public static string HashPassword(string password)
		{
			byte[] salt;
			byte[] buffer2;
			if (password == null)
			{
				throw new ArgumentNullException("password");
			}
			using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
			{
				salt = bytes.Salt;
				buffer2 = bytes.GetBytes(0x20);
			}
			byte[] dst = new byte[0x31];
			Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
			Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
			return Convert.ToBase64String(dst);
		}
		public static bool ByteArraysEqual(byte[] b1, byte[] b2)
		{
			if (b1 == b2) return true;
			if (b1 == null || b2 == null) return false;
			if (b1.Length != b2.Length) return false;
			for (int i = 0; i < b1.Length; i++)
			{
				if (b1[i] != b2[i]) return false;
			}
			return true;
		}
		public static bool VerifyHashedPassword(string hashedPassword, string password)
		{
			byte[] buffer4;
			if (hashedPassword == null)
			{
				return false;
			}
			if (password == null)
			{
				throw new ArgumentNullException("password");
			}
			byte[] src = Convert.FromBase64String(hashedPassword);
			if ((src.Length != 0x31) || (src[0] != 0))
			{
				return false;
			}
			byte[] dst = new byte[0x10];
			Buffer.BlockCopy(src, 1, dst, 0, 0x10);
			byte[] buffer3 = new byte[0x20];
			Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
			using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
			{
				buffer4 = bytes.GetBytes(0x20);
			}
			
			return ByteArraysEqual(buffer3, buffer4);
		}
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
			if (user.Email != null)
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
			User user = new User();
			string passwordSend = HashPassword(password);
			user = unit.Users.Get(u => u.login == email);
			if (user != null)
			{
				if (VerifyHashedPassword(user.password, password))
				{
					account.Email = user.login;
					account.Password = user.password;
					//Role role = unit.context.Roles
					account.Role = user.Role;
				}
			
			}

			return account;
		}
		private string GenerateJWT(Account user)
		{
			var authParams = authOptions.Value;
			var securityKey = AuthOptions.GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			if (user.Email != null)
			{
				var claims = new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())

			};
				claims.Add(new Claim("role", user.Role.name_role));
				claims.Add(new Claim("Name", user.Email));
				var token = new JwtSecurityToken(AuthOptions.ISSUER,
	AuthOptions.AUDIENCE,
	claims,
	expires: DateTime.Now.AddSeconds(AuthOptions.LIFETIME),
	signingCredentials: credentials);
				return new JwtSecurityTokenHandler().WriteToken(token);
			}
			return "null";
			//foreach (var role in user.Roles)
			//{
			//}

		}
	}
}
