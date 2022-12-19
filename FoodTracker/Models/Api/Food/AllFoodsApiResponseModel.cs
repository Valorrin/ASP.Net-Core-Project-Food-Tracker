namespace FoodTracker.Models.Api.Food
{
    public class AllFoodsApiResponseModel
    {
        public int CurrentPage { get; set; }

        public int TotalFoods { get; set; }

        public IEnumerable<FoodResponseModel> Foods { get; init; }

    }
}
