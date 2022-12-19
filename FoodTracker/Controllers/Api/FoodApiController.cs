using FoodTracker.Data;
using FoodTracker.Models;
using FoodTracker.Data.Models;
using FoodTracker.Models.Api.Food;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using FoodTracker.Services.Food;

namespace FoodTracker.Controllers.Api
{
    [ApiController]
    [Route("api/foods")]
    public class FoodApiController : ControllerBase
    {
        private readonly IFoodService food;

        public FoodApiController(IFoodService food)
            => this.food = food;


        [HttpGet]
        public FoodQueryServiceModel All([FromQuery] AllFoodsApiRequestModel query)
        {
            return this.food.All(
                query.Name,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.FoodsPerPage);
        }
    }
}
