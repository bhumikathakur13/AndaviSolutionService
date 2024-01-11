using Microsoft.EntityFrameworkCore;

namespace AndaviSolutionService.Models
{
    [Keyless]
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }

}
