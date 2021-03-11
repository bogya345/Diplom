using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using WebBRS.Controllers;
using WebBRS.Services.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using WebBRS.DAL;
using Microsoft.EntityFrameworkCore;

namespace WebBRS
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			// In production, the Angular files will be served from this directory
			services.AddAuthentication(IISDefaults.AuthenticationScheme);
			services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					   .AddJwtBearer(options =>
					   {
						   options.RequireHttpsMetadata = false;
						   options.TokenValidationParameters = new TokenValidationParameters
						   {
								// укзывает, будет ли валидироваться издатель при валидации токена
								ValidateIssuer = true,

								// строка, представляющая издателя
								ValidIssuer = AuthOptions.ISSUER,

								// будет ли валидироваться потребитель токена
								ValidateAudience = true,

								// установка потребителя токена
								ValidAudience = AuthOptions.AUDIENCE,

								// будет ли валидироваться время существования
								ValidateLifetime = true,

								// установка ключа безопасности
								IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

								// валидация ключа безопасности
								ValidateIssuerSigningKey = true,
						   };
					   });
			services.AddControllersWithViews();
			services.AddDbContext<MyContext>(
	   options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
				//options.JsonSerializerOptions.Converters.Add(MyCu)
			});
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}
	}
}
