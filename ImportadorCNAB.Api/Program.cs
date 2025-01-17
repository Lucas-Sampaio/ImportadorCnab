using ImportadorCNAB.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApiConfiguration(builder.Configuration, builder.Environment);
builder.Services.RegisterServices();
builder.Services.AddCustomHealthChecks(builder.Configuration, builder.Environment);
//swagger
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseAuthorization();
app.UseApiConfiguration();
app.UseCustomHealthCheckConfiguration();

app.Run();
public partial class Program { }