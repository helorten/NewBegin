using Microsoft.EntityFrameworkCore;
using NewBegin.Data.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        Database.EnsureCreated();
    }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<BusinessModel> Businesses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var basePath = AppContext.BaseDirectory;
        var connectionStringPath = Path.Combine(basePath, "dbConnection.txt");
        var connectionString = File.ReadAllText(connectionStringPath);

        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 37)), b => b.MigrationsAssembly("NewBegin.Infrastructure"));
    }
}