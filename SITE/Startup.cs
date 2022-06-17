using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SITE.Domain;
using SITE.Domain.Repositories.Abstract;
using SITE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());
            //���������� ������ �� appsettings.json

            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<IOrdersRepository, EFOrdersRepository>();
            services.AddTransient<DataManager>();
            //���������� ����� ���������� � �������� ��������

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));
            //���������� �������� ��

            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            //��������� identity �������

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "SITEAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });
            //��������� ���� �����������
            
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });
            //����������� �������� ����������� ��� Admin area

            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest)
                .AddSessionStateTempDataProvider();
                //��������� ��������� ������������ MVC
                
            //�������������
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            //���������� �� �������

            app.UseStaticFiles();
            //��������� ��������� ������

            app.UseRouting();
            //����� ������� �������������

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            //������������ ��������
        }
    }
}
