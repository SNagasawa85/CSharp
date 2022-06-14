using Microsoft.EntityFrameworkCore;
namespace ChefsDishes.Models;

public class ChefContext : DbContext
{
    public ChefContext(DbContextOptions options) : base(options) { }
    public DbSet<Chef> Chefs {get; set;} = null!;
    public DbSet<Dish> Dishes {get; set;} = null!;
    
}