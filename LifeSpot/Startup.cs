using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/wwwroot/css/index.css", async context =>
                {
                    // �� �������� �� ��������� Index �������� �� ����� ������� ���� �� �������� �� �������, ����� ������� ����, ������ �� ���������
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "index.css");
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });
                endpoints.MapGet("/wwwroot/js/greeting.js", async context =>
                {
                    // �� �������� �� ��������� Index �������� �� ����� ������� ���� �� �������� �� �������, ����� ������� ����, ������ �� ���������
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "js", "greeting.js");
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });
                endpoints.MapGet("/", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
                    var html = await File.ReadAllTextAsync(viewPath);
                    await context.Response.WriteAsync(html);
                });
            });
        }
    }
}