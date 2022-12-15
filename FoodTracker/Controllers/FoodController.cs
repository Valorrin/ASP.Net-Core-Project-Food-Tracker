using System.Collections.Generic;
using System.Linq;
using FoodTracker.Data;
using FoodTracker.Data.Models;
using FoodTracker.Models.Food;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodTracker.Controllers
{
    public class FoodController : Controller
    {
        private readonly FoodTrackerDbContext data;

        public FoodController(FoodTrackerDbContext data) => this.data = data;

        public IActionResult Add() => View(new AddFoodFormModel
        {
            Categories = this.GetFoodCategories()
        });

        public IActionResult All(string searchTerm)
        {
            var foodsQuery = this.data.Food.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                foodsQuery = foodsQuery.Where(f =>
                    f.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            var foods = foodsQuery
                .OrderByDescending(f => f.Id)
                .Select(f => new FoodListingViewModel
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

            return View(new FoodSearchQueryModel
            {
                Foods = foods,
                SearchTerm = searchTerm
            });
        }

        [HttpPost]
        public IActionResult Add(AddFoodFormModel food)
        {
            if (!this.data.Categories.Any(c=> c.Id == food.CategoryId))
            {
                this.ModelState.AddModelError(nameof(food.CategoryId), "Category don't exist");
            }

            if (!ModelState.IsValid)
            {
                food.Categories = this.GetFoodCategories();
  
                return View(food);
            }

            var foodData = new Food
            {
                Name = food.Name,
                Grams = food.Grams,
                Calories = food.Calories,
                Protein = food.Protein,
                Carbs = food.Carbs,
                Fat = food.Fat,
                CategoryId = food.CategoryId,
            };

            this.data.Food.Add(foodData);

            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<FoodCategoryViewModel> GetFoodCategories()
            => this.data
                .Categories
            .Select(f => new FoodCategoryViewModel
            {
                Id = f.Id,
                Name = f.Name,
            })
            .ToList();

    }
}
