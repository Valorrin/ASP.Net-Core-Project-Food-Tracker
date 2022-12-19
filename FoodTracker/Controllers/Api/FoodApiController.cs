using FoodTracker.Data;
using FoodTracker.Data.Models;
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
        public IEnumerable GetFood()
        {
            return this.data.Food.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDetails(int id)
        {
            var food = this.data.Food.Find(id);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

    }
}
