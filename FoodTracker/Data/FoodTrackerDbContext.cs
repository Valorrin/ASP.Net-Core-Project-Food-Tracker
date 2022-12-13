using FoodTracker.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodTracker.Data
{
    public class FoodTrackerDbContext : IdentityDbContext
    {
        public FoodTrackerDbContext(DbContextOptions<FoodTrackerDbContext> options)
            : base(options)
        {
        }


        public DbSet<Food> Food { get; init; }


        public DbSet<Category> Categories { get; init; }

    }
}