namespace ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

public class ProdCatContext : DbContext
{
    public ProdCatContext(DbContextOptions options) : base(options) { }
    public DbSet<Product> Products {get; set;} = null!;
    public DbSet<Category> Categories {get; set;} = null!;
    public DbSet<Association> Associations {get; set;} = null!;
}