using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Models
{
    public class BestRestaurantsContext : DbContext
    {
        public DbSet<Cuisine> Cuisine { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public BestRestaurantsContext(DbContextOptions options) : base(options) {}
    }
}