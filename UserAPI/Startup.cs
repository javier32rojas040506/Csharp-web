using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace UserAPI
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configuración del CORS (permitir todas las solicitudes de cualquier origen y método)
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            // Otros servicios y configuraciones...
        }

        public void Configure(IApplicationBuilder app)
        {
            // Otras configuraciones de middleware...

            app.UseCors("AllowAll"); // Usar la política CORS "AllowAll"

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
