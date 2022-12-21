using FoodTracker.Services.Food;

namespace FoodTracker.Models.Food
{
    public class FoodSearchQueryModel
    {
        public const int FoodsPerPage = 5;

        public string Name { get; set; }
        public IEnumerable<string> Names { get; set; }

        public string SearchTerm { get; set; }

        public FoodSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalFoods { get; set; }

        public IEnumerable<FoodServiceModel> Foods { get; set; }
    }
}
