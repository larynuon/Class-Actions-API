using Class_Actions_API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class_Actions_API
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Client/Error");
                app.UseHsts();
            }
            //middleware pipline
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //used to match URLs of incoming requests and map them with the controller action
            //routes defined in the startup code 
            //routing descirbes how the URL paths are matched with the action 
            //routing is used to generate URLs for links
            //define use of tehcnolgy endpoint (MVC)
            app.UseRouting();

            app.UseAuthorization();

            
            // controller / action / id (action parameter)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Client}/{action=Index}/{id?}");
            });

            //Dedicated Conventional routing 
            //uses conventional routing but it is dedicated to a blog 

            //Attribute Based routing


        }
    }
}
