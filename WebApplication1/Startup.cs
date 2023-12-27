using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Этот метод вызывается во время выполнения. Используется для добавления сервисов в контейнер зависимостей.
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавление сервисов, таких как контроллеры, сервисы для работы с данными, авторизация и др.
            services.AddControllers();

            // Добавление Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
            });
        }

        // Этот метод вызывается во время выполнения. Используется для настройки конвейера HTTP-запроса.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // В продакшн режиме можно добавить обработку ошибок и другие механизмы безопасности.
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Добавление маршрутизации и обработки статических файлов (если требуется)
            app.UseRouting();

            // Добавление авторизации и аутентификации (если требуется)
            // app.UseAuthentication();
            // app.UseAuthorization();

            // Настройка маршрутов контроллеров
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // Включение Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });
        }
    }
}
