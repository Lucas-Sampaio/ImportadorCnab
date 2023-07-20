using ImportadorCNAB.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.RegisterServices();

//swagger
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseAuthorization();
app.UseApiConfiguration();

app.Run();