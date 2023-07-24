using ImportadorCNAB.Api.Filters;
using ImportadorCNAB.Infra;
using Microsoft.EntityFrameworkCore;

namespace ImportadorCNAB.Api.Configuration;

public static class ApiConfig
{
    public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddControllers(options =>
        options.Filters.Add(typeof(HttpGlobalExceptionFilter)));

        services.AddEndpointsApiExplorer();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

        var connection = configuration.GetConnectionString("SQLConnection");

        services.AddDbContext<ClienteContext>(options =>
        {
            options
            .UseSqlServer(connection, config => config.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null));
        });

        if (!environment.IsEnvironment("Testing"))
        {
            using var scope = services.BuildServiceProvider();
            var db = scope.GetRequiredService<ClienteContext>();
            db.Database.Migrate();
        }
    }

    public static void UseApiConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.MapControllers();
        app.UseHttpsRedirection();
    }
}