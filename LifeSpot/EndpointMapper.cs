using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System.Text;

namespace LifeSpot
{
    public static class EndpointMapper
    {
        public static void MapCss(this IEndpointRouteBuilder builder)
        {
            var cssFiles = new[] { "index.css" };

            foreach (var fileName in cssFiles)
            {
                builder.MapGet($"/wwwroot/css/{fileName}", async context =>
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", fileName);
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });
            }
        }

        public static void MapJs(this IEndpointRouteBuilder builder)
        {
            var jsFiles = new[] { "index.js", "testing.js", "about.js" };

            foreach (var fileName in jsFiles)
            {
                builder.MapGet($"/wwwroot/js/{fileName}", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "js", fileName);
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });
            }
        }

        public static void MapJpg(this IEndpointRouteBuilder builder)
        {
            // Массив файлов JPG, которые будут доступны по HTTP
            var jpgFiles = new[] { "london.jpg", "ny.jpg", "spb.jpg" };

            // Перебираем каждый файл из массива jpgFiles
            foreach (var fileName in jpgFiles)
            {
                // Добавляем маршрут для обработки GET-запросов к каждому изображению
                builder.MapGet($"/wwwroot/img/{fileName}", async context =>
                {
                    // Формируем полный путь к файлу JPG, используя текущую директорию и имя файла
                    var jpgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", fileName);

                    // Проверяем, существует ли файл по указанному пути
                    if (File.Exists(jpgPath))
                    {
                        // Устанавливаем тип контента для ответа как "image/jpeg"
                        context.Response.ContentType = "image/jpeg";

                        // Asynchronously читаем все байты из файла JPG
                        var jpgBytes = await File.ReadAllBytesAsync(jpgPath);

                        // Записываем байты изображения в тело ответа
                        await context.Response.Body.WriteAsync(jpgBytes, 0, jpgBytes.Length);
                    }
                    else
                    {
                        // Если файл не найден, устанавливаем статус ответа 404 (Не найдено)
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                    }
                });
            }
        }

        public static void MapHtml(this IEndpointRouteBuilder builder)
        {
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sidebar.html"));
            string sliderHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "slider.html"));

            builder.MapGet("/", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
                var viewText = await File.ReadAllTextAsync(viewPath);

                // Загружаем шаблон страницы, вставляя в него элементы
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);

                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/testing", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "testing.html");

                // Загружаем шаблон страницы, вставляя в него элементы
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);

                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/about", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "about.html");

                // Загружаем шаблон страницы, вставляя в него элементы
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml)
                    .Replace("<!--SLIDER-->", sliderHtml);

                await context.Response.WriteAsync(html.ToString());
            });
        }
    }
};
