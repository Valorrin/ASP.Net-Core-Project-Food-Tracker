using FoodTracker.Data;
using FoodTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTracker.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static WebApplication PrepareDatabase(
            this WebApplication app)
        {

            using var scope = app.Services.CreateScope();

            var data = scope.ServiceProvider.GetRequiredService<FoodTrackerDbContext>();
            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(FoodTrackerDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Vegetables" },
                new Category { Name = "Fruits" },
                new Category { Name = "Grains, Beans and Nuts" },
                new Category { Name = "Meat and Poultry" },
                new Category { Name = "Fish and Seafood" },
                new Category { Name = "Dairy " },
            });

            data.SaveChanges();
        }
    }
}
