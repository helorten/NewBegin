using Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(new JsonFormatter(), "Logs/log-.txt", rollingInterval: RollingInterval.Minute)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers()
            .AddApplicationPart(typeof(NewBegin.API.Controllers.UserController).Assembly)
            .AddControllersAsServices();




var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHsts();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
