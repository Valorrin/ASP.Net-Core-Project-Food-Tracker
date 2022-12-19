using System.ComponentModel.DataAnnotations;

using static FoodTracker.Data.DataConstants.Category;

namespace FoodTracker.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Food> Food { get; set; } = new List<Food>();
    }
}
