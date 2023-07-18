using ImportadorCNAB.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ImportadorCNAB.Api.Configuration;

public static class ApiConfig
{
    public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());


        var connection = configuration.GetConnectionString("SQLConnection");

        services.AddDbContext<ClienteContext>(options =>
        {
            options
            .UseSqlServer(connection, config => config.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null));
        });

        //services.AddControllers(options =>
        //{
        //    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
        //});
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