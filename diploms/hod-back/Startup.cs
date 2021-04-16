using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hod_back.DAL;
using hod_back.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using AutoMapper;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using hod_back.Configs;

namespace hod_back
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<FormOptions>(options =>
            //{
            //    options.MemoryBufferThreshold = Int32.MaxValue;
            //});

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(
                                          "https://localhost:4200"
                                          , "http://localhost:4200"

                                          , "https://192.168.43.86:4200"
                                          , "http://192.168.43.86:4200"
                                          )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin()
                                        ;
                                  });
            });

            services.Configure<BaseConfig>(Configuration);

            services.AddAutoMapper(
                typeof(DepartmentsProfile)
                );

            //services.Add

            services.AddSingleton<UnitOfWork>();

            //services.AddSingleton<Context, SystemDateTime>();

            // services.AddResponseCaching();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"_Resources")),
                RequestPath = new PathString("/_Resources")
            });

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            // app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
