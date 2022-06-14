using Microsoft.EntityFrameworkCore;
namespace LoginRegistration.Models;

public class UserContext : DbContext
{
        public UserContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get; set;} = null!;

}
