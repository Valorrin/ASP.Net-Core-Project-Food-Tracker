using FoodTracker.Data;
using FoodTracker.Models.Api.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace FoodTracker.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController: ControllerBase
    {

        private readonly FoodTrackerDbContext data;

        public StatisticsApiController(FoodTrackerDbContext data)
            => this.data = data;

        [HttpGet]
        public StatisticsResponseModel GetStatistics()
        {
            var totalFoods = this.data.Food.Count();
            var totalUsers = this.data.Users.Count();

            return new StatisticsResponseModel
            {
                TotalFoods = totalFoods,
                TotalUsers = totalUsers,
                TotalRecipies = 0
            };

        }
    }
}
