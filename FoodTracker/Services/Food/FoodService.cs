using FoodTracker.Data;
using FoodTracker.Models;

namespace FoodTracker.Services.Food
{
    public class FoodService : IFoodService
    {
        private readonly FoodTrackerDbContext data;

        public FoodService(FoodTrackerDbContext data)
            => this.data = data;

        public FoodQueryServiceModel All(
            string name,
            string searchTerm,
            FoodSorting sorting,
            int currentPage,
            int foodsPerPage
            )
        {
            var foodsQuery = this.data.Food.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                foodsQuery = foodsQuery.Where(f =>
                    f.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            foodsQuery = sorting switch
            {
                FoodSorting.NameAscending => foodsQuery.OrderBy(f => f.Name),
                FoodSorting.NameDescending => foodsQuery.OrderByDescending(f => f.Name),
                FoodSorting.MostRecent or _ => foodsQuery.OrderByDescending(f => f.Id)
            };

            var totalFoods = foodsQuery.Count();

            var foods = foodsQuery
                .Skip((currentPage - 1) * foodsPerPage)
                .Take(foodsPerPage)
                .Select(f => new FoodServiceModel
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

            return new FoodQueryServiceModel
            {
                CurrentPage = currentPage,
                TotalFoods = totalFoods,
                FoodsPerPage = foodsPerPage,
                Foods = foods,
            };
        }
    }
}
