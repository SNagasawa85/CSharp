namespace WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

public class WeddingContext : DbContext
{
    public WeddingContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users {get; set;} = null!;
    public DbSet<Wedding> Weddings {get; set;} = null!;
    public DbSet<Association> Associations {get; set;} = null!;
}