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
    }
}
