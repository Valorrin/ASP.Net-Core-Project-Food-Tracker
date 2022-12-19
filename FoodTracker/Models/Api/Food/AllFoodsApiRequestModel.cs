using FoodTracker.Models;

namespace FoodTracker.Models.Api.Food
{
    public class AllFoodsApiRequestModel
    {
        public string? Name { get; set; }

        public string? SearchTerm { get; set; }

        public FoodSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int FoodsPerPage { get; set; } = 10;
        public int TotalFoods { get; set; }
    }
}
