using Microsoft.EntityFrameworkCore;

namespace Bestaurant.Models
{
  public class BestaurantContext : DbContext
  {
    public virtual DbSet<Cuisine> Cuisines {get;set;}
    public DbSet<Restaurant> Restaurants {get;set;}

    public BestaurantContext(DbContextOptions options) : base(options) { }
  }
}