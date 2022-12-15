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

        [HttpPost]
        public IActionResult Add(AddFoodFormModel food)
        {
            if (!this.data.Categories.Any(c => c.Id == food.CategoryId))
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


        public IActionResult All([FromQuery] FoodSearchQueryModel query)
        {
            var foodsQuery = this.data.Food.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                foodsQuery = foodsQuery.Where(f =>
                    f.Name.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            foodsQuery = query.Sorting switch
            {
                FoodSorting.NameAscending => foodsQuery.OrderBy(f=>f.Name),
                FoodSorting.NameDescending => foodsQuery.OrderByDescending(f=>f.Name),
                FoodSorting.MostRecent or _=> foodsQuery.OrderByDescending(f=>f.Id)
            };

            var totalFoods = foodsQuery.Count();

            var foods = foodsQuery
                .Skip((query.CurrentPage - 1) * FoodSearchQueryModel.FoodsPerPage)
                .Take(FoodSearchQueryModel.FoodsPerPage)
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

            var foodNames = this.data
                .Food
                .Select(f => f.Name)
                .Distinct()
                .OrderBy(fn => fn)
                .ToList();

            query.TotalFoods = totalFoods;
            query.Names = foodNames;
            query.Foods = foods;

            return View(query);
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
