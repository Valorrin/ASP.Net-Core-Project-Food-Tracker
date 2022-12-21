using System.Collections.Generic;
using System.Linq;
using FoodTracker.Data;
using FoodTracker.Data.Models;
using FoodTracker.Models;
using FoodTracker.Models.Food;
using FoodTracker.Services.Food;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodTracker.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService food;
        private readonly FoodTrackerDbContext data;
        public FoodController(FoodTrackerDbContext data, IFoodService food)
        {
            this.data = data;
            this.food = food;
        }

        public IActionResult All([FromQuery] FoodSearchQueryModel query)
        {
            var queryResult = this.food.All(
                query.Name,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                FoodSearchQueryModel.FoodsPerPage);



            var foodNames = this.food.AllFoodNames();

            query.TotalFoods = queryResult.TotalFoods;
            query.Names = foodNames;
            query.Foods = queryResult.Foods;


            return View(query);
        }


        public IActionResult Add() => View(new AddFoodFormModel
        {
            Categories = this.food.GetFoodCategories()
        });

        [HttpPost]
        public IActionResult Add(AddFoodFormModel food)
        {
            if (!this.data.Categories.Any(c => c.Id == food.CategoryId))
            {
                this.ModelState.AddModelError(nameof(food.CategoryId), "Category don't exist");
            }

            if (!ModelState.IsValid)
            {
                food.Categories = this.food.GetFoodCategories();

                return View(food);
            }

            this.food.Create(
                food.Name,
                food.Grams,
                food.Calories,
                food.Protein,
                food.Carbs,
                food.Fat,
                food.CategoryId);

            return RedirectToAction(nameof(All));
        }
    }
}
