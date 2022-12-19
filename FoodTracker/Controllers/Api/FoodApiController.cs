using FoodTracker.Data;
using FoodTracker.Models;
using FoodTracker.Data.Models;
using FoodTracker.Models.Api.Food;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FoodTracker.Controllers.Api
{
    [ApiController]
    [Route("api/foods")]
    public class FoodApiController : ControllerBase
    {
        private readonly FoodTrackerDbContext data;

        public FoodApiController(FoodTrackerDbContext data)
            => this.data = data;

        [HttpGet]
        [Route("аll")]
        public IEnumerable GetFood()
        {
            return this.data.Food.ToList();
        }


        [HttpGet]
        public ActionResult<AllFoodsApiResponseModel> All([FromQuery] AllFoodsApiRequestModel query)
        {
            var foodsQuery = this.data.Food.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                foodsQuery = foodsQuery.Where(f =>
                    f.Name.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            foodsQuery = query.Sorting switch
            {
                FoodSorting.NameAscending => foodsQuery.OrderBy(f => f.Name),
                FoodSorting.NameDescending => foodsQuery.OrderByDescending(f => f.Name),
                FoodSorting.MostRecent or _ => foodsQuery.OrderByDescending(f => f.Id)
            };

            var totalFoods = foodsQuery.Count();

            var foods = foodsQuery
                .Skip((query.CurrentPage - 1) * query.FoodsPerPage)
                .Take(query.FoodsPerPage)
                .Select(f => new FoodResponseModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    Grams = f.Grams,
                    Calories = f.Calories,
                    Protein = f.Protein,
                    Carbs = f.Carbs,
                    Fat = f.Fat
                })
                .ToList();

            return new AllFoodsApiResponseModel
            {
                CurrentPage = query.CurrentPage,
                TotalFoods = totalFoods,
                Foods = foods
            };

        }
    }
}
