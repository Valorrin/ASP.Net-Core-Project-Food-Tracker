using FoodTracker.Models;

namespace FoodTracker.Services.Food
{
    public interface IFoodService
    {
        FoodQueryServiceModel All(
            string name,
            string searchTerm,
            FoodSorting sorting,
            int currentPage,
            int foodsPerPage);

        int Create(
            string name,
            double grams,
            double calories,
            double protein,
            double carbs,
            double fat,
            int categoryId);

        IEnumerable<string> AllFoodNames();

        IEnumerable<FoodCategoryServiceModel> GetFoodCategories();

    }
}
