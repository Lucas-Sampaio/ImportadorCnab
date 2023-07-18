using ImportadorCNAB.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var baseUrlApi = builder.Configuration.GetValue<string>("Base_url_ImportadorApi");

builder.Services.AddHttpClient<IImportadorCNABService, ImportadorCNABService>()
    .ConfigureHttpClient(x =>
    {
        x.BaseAddress = new Uri(baseUrlApi);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();