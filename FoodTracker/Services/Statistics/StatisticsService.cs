using FoodTracker.Data;

namespace FoodTracker.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly FoodTrackerDbContext data;

        public StatisticsService(FoodTrackerDbContext data)
            => this.data = data;

        public StatisticsServiceModel Total()
        {
            var totalFoods = this.data.Food.Count();
            var totalUsers = this.data.Users.Count();

            return new StatisticsServiceModel
            {
                TotalFoods = totalFoods,
                TotalUsers = totalUsers,
            };

        }
    }
}
