namespace FoodTracker.Models.Food
{
    public class FoodSearchQueryModel
    {
        public string Name { get; set; }
        public IEnumerable<string> Names { get; set; }

        public string SearchTerm { get; set; }

        public FoodSorting Sorting {get; set;}

        public IEnumerable<FoodListingViewModel> Foods { get; set; }
    }
}
