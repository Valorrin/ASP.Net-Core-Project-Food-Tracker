namespace FoodTracker.Data.Models
{
    public class Diary
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double CalorieTarget { get; set; }

        public double TotalCalories { get; set; } = 0;

        public IEnumerable<Food> Foods { get; set; } = new List<Food>();
    }
}
