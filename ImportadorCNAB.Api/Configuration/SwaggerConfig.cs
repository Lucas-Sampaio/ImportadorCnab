using Microsoft.OpenApi.Models;

namespace ImportadorCNAB.Api.Configuration;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "ImportadorCnab example api",
                Description = "Esta API faz parte de um projeto",
                Contact = new OpenApiContact() { Name = "Lucas Sampaio", Email = "lucasssouza29@hotmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });
    }
    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
