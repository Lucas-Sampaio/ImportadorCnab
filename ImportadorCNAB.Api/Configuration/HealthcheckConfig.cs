using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

namespace ImportadorCNAB.Api.Configuration;

public static class HealthcheckConfig
{
    public static void AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        var connectionSql = configuration.GetConnectionString("SQLConnection");

        services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), tags: new string[] { "api", "Importador" })
            .AddSqlServer(connectionSql, name: "BancoSQL",
            tags: new string[] { "db", "sql", "sqlserver" }, timeout: TimeSpan.FromSeconds(10));

        var endpoinHc = environment.IsProduction()
            ? $"http://{Dns.GetHostName()}/api/hc"
            : "/api/hc";

        services.AddHealthChecksUI(setup =>
        {
            setup.SetEvaluationTimeInSeconds(5); //tempo para consultar a api
            setup.SetApiMaxActiveRequests(3); //maximo de tentativas ativas
            setup.MaximumHistoryEntriesPerEndpoint(50); //maximo de logs de estado
            setup.AddHealthCheckEndpoint("api importador", endpoinHc);
        }).AddInMemoryStorage();
    }

    public static void UseCustomHealthCheckConfiguration(this IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseHealthChecks("/api/hc", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI(options =>
        {
            options.UIPath = "/api/hc-dashboard";
            options.ResourcesPath = $"{options.UIPath}/resources";
            options.UseRelativeApiPath = false;
            options.UseRelativeResourcesPath = false;
            options.UseRelativeWebhookPath = false;
        });
    }
}