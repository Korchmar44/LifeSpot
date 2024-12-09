using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            // ��������� ��������� �������� ��� ������� � ������: ������� ���� � �����
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sideBar.html"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
                    var html = await File.ReadAllTextAsync(viewPath);
                    await context.Response.WriteAsync(html);
                });
                endpoints.MapGet("/testing", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "testing.html");

                    // ��������� ������ ��������, �������� � ���� ��������
                    var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                        .Replace("<!--SIDEBAR-->", sideBarHtml)
                        .Replace("<!--FOOTER-->", footerHtml);

                    await context.Response.WriteAsync(html.ToString());
                });
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
                endpoints.MapGet("/wwwroot/js/testing.js", async context =>
                {
                    // �� �������� �� ��������� Index �������� �� ����� ������� ���� �� �������� �� �������, ����� ������� ����, ������ �� ���������
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "js", "testing.js");
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });
            });
        }
    }
}