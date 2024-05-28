var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
            .AddApplicationPart(typeof(NewBegin.API.Controllers.UserController).Assembly).AddControllersAsServices();

using (var context = new ApplicationDbContext())
{
    var products = context.Users.ToList();
    foreach (var p in products)
    {
        Console.WriteLine($"Name: {p.Name}, Id: {p.Id}");
    }
}

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
