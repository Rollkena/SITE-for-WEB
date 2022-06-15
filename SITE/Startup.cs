using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            //подключаем конфиг из appsettings.json
            services.AddControllersWithViews()
                //добавляем поддержку контроллеров MVC
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest)
                .AddSessionStateTempDataProvider();
            //совместимость
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //информация об ошибках

            app.UseRouting();

            app.UseStaticFiles();
            //поддержка статичных файлов

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
