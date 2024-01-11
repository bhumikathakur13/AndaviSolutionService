using Microsoft.EntityFrameworkCore;

namespace AndaviSolutionService.Models
{
    [Keyless]
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
    }

    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
