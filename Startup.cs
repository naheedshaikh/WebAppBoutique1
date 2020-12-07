using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//Make sure you make the following imports (AFTER dbcontext and model have been created
//using WebAppBoutique1.Data;
using WebAppBoutique1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Mvc;

namespace WebAppBoutique1
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
           // services.AddRazorPages();
           // services.AddMvc();

            //Here, we disable endpoint routing. This was an issue when upgrading from ASP.NET CORE 2.0 to ASP.NET Core 3.0
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options => options.EnableEndpointRouting = false);

            //Adding connection
            string connection = @"Server=(localdb)\mssqllocaldb;Database=WebAppBoutique1;Trusted_Connection=True;ConnectRetryCount=0";
            //Adding Db Context
            services.AddDbContext<ItemContext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<ItemContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            //UseStaticFiles allow us to use CSS or image files that we put in wwwroot
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //default
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
