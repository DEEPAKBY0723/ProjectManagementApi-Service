using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration;
using ProjectManagementApi.Business;
using ProjectManagementApi.DataAccess;
using ProjectManagementApi.EfCore;

namespace ProjectManagementApi
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IUserBlc, UserBlc>();
            services.AddScoped<IUserDalc, UserDalc>();
            services.AddScoped<IProjectBlc, ProjectBlc>();
            services.AddScoped<IProjectDalc, ProjectDalc>();
            services.AddScoped<ITaskBlc, TaskBlc>();
            services.AddScoped<ITaskDalc, TaskDalc>();
            services.AddDbContext<ReportServerContext>();
            
            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("CORSPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
