using NewBegin.Data.Models;

var builder = WebApplication.CreateBuilder(args);
using (var context = new ApplicationDbContext())
{
    // Получение всех продуктов
    var products = context.Users.ToList();
    foreach (var p in products)
    {
        Console.WriteLine($"Name: {p.Name}, Id: {p.Id}");
    }
}
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
