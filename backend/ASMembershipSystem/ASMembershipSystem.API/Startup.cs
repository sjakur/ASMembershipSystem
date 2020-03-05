using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASMembershipSystem.Core.Contracts;
using ASMembershipSystem.Core.Services;
using ASMembershipSystem.DataAccess;
using ASMembershipSystem.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASMembershipSystem.API
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
            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            EnsureDatabaseExists();
            services.AddDbContext<ASMembershipContext>(options => options.UseInMemoryDatabase("ASMembershipSystem"));
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<ISportService, SportService>();
            services.AddTransient<ISportRepository, SportRepository>();
        }

        private static void EnsureDatabaseExists()
        {
            var options = new DbContextOptionsBuilder<ASMembershipContext>()
                              .UseInMemoryDatabase("ASMembershipSystem")
                              .Options;
            var context = new ASMembershipContext(options);
            context.Database.EnsureCreated();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
