namespace FoodTracker.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Food> Food { get; set; } = new List<Food>();
    }
}
