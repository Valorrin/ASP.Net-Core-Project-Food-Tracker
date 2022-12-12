using FoodTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodTracker.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static WebApplication PrepareDatabase(
            this WebApplication app)
        {

            using var scope = app.Services.CreateScope();

            var dataContext = scope.ServiceProvider.GetRequiredService<FoodTrackerDbContext>();
            dataContext.Database.Migrate();

            return app;
        }
    }
}
