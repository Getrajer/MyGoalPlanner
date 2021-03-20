using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyGoalPlanner.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyGoalPlanner.Api
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddScoped<IFontAwesomeRepository, SQLFontAwesomeRepository>();
            services.AddScoped<IGoalConditionRepository, SQLGoalConditionRepository>();
            services.AddScoped<IGoalItemRepository, SQLGoalItemRepository>();
            services.AddScoped<IGoalRepository, SQLGoalRepository>();
            services.AddScoped<IMotivatorRepository, SQLMotivatorRepository>();
            services.AddScoped<INoteRepository, SQLNoteRepository>();
            services.AddScoped<IStepRepostitory, SQLStepRepository>();
            services.AddScoped<ITypeOfGoalRepository, SQLTypeOfGoalRepository>();
            services.AddScoped<IActivityRepository, SQLActivityRepository>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
