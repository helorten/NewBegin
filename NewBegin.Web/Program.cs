using Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Formatting.Json;
using Microsoft.OpenApi.Models;
using NewBegin.Infrastructure.Repositories.Interfaces;
using NewBegin.Services.Intefaces;
using NewBegin.Infrastructure.Repositories.Implementations;
using NewBegin.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(new JsonFormatter(), "Logs/log-.txt", rollingInterval: RollingInterval.Minute)
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers()
            .AddApplicationPart(typeof(NewBegin.API.Controllers.UserController).Assembly)
            .AddControllersAsServices();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "NewBegin APIs",
    });
});


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});


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
