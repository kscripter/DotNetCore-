using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagwmwntSystemEFWeb.Domain.Repository;
using BankManagwmwntSystemEFWeb.Domain.Service;
using BankManagwmwntSystemEFWeb.Interface.Repository;
using BankManagwmwntSystemEFWeb.Interface.Service;
using BankManagwmwntSystemEFWeb.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankManagwmwntSystemEFWeb
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
            services.AddDbContext<ApplicationContext>(Options => Options.UseMySQL(Configuration.GetConnectionString("ApplicationContextConnection")));
            services.AddScoped<IAccountHolderRepository, AccountHolderRepository>();
            services.AddScoped<IAccountHolderService, AccountHolderService>();

            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IManagerService, ManagerService>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILoanService, LoanService>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
            {
                config.LoginPath = "/login";
                config.Cookie.Name = "Library";
            });


            //UseMySQL
            //UseSQLServer

            //------//files to be downloaded and installed each time you setup a new project:-------:
            //"entity frame work core" inorder to use "DbContext" (from NuGET Packages)
            //"MYSQL.data"   and  "MYSQL entityframeWork" inorder to use "UseMySQL" (from NuGET Packages)
            //"UseSqlServer" to use this install from nuget packages "sql server"



            //"ENtityFrameWorkTools" "design" in order to migrate to your database (from NuGET Packages)
            //"ENtityFrameWorkTools" in order to migrate to your database (from command line prompt)


            //dotnet tool install --global dotnet-ef
            //dotnet add package Microsoft.EntityFrameworkCore.Design


            //after installation: run migration (dotnet ef migrations add -p scorebankefweb  -s scorebankefweb secondproject)
            //after migration run update        (dotnet ef database update -p scorebankefweb -s scorebankefweb secondproject)


            //after installation: run migration (dotnet ef migrations add -p BankManagwmwntSystemEFWeb  -s BankManagwmwntSystemEFWeb thirdwebinitial)

            //after migration run update        (dotnet ef database update -p BankManagwmwntSystemEFWeb -s BankManagwmwntSystemEFWeb thirdwebinitial)


            //--------------------------------  BankManagwmwntSystemEFWeb

            //files to be downloaded and installed each time you setup a new project
            //"entity frame work core" inorder to use "DbContext" (from NuGET Packages)
            //"MYSQL.data"   and  "MYSQL entityframeWork" inorder to use "UseMySQL" (from NuGET Packages)
            //"ENtityFrameWorkTools" in order to migrate to your database (from NuGET Packages)
            //"ENtityFrameWorkTools" in order to migrate to your database (from command line prompt)


            //dotnet tool install --global dotnet-ef
            //dotnet add package Microsoft.EntityFrameworkCore.Design

            //dotnet add <PROJECT> package [options] <PACKAGE_NAME>


            //after installation: run migration (dotnet ef migrations add -p scorebankefweb  -s scorebankefweb secondproject)
            //after migration run update(dotnet ef database update -p scorebankefweb -s scorebankefweb secondproject)
            //lastly install from nuget packages ("dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design")
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
