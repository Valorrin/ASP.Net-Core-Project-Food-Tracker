namespace FoodTracker.Services.Food
{
    public class FoodQueryServiceModel
    {
        public string Name { get; set; }
        public int CurrentPage { get; set; }

        public int TotalFoods { get; set; }

        public int FoodsPerPage { get; set; }

        public IEnumerable<FoodServiceModel> Foods { get; init; }
    }
}
