using System.ComponentModel.DataAnnotations;

using static FoodTracker.Data.DataConstants;

namespace FoodTracker.Data.Models
{
    public class Food
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(FoodNameMaxLength)]
        public string Name { get; init; }

        [Range(FoodGramsMinValue, FoodGramsMaxValue)]
        public double Grams { get; init; }

        [Range(FoodCaloriesMinValue, FoodCaloriesMaxValue)]
        public double Calories { get; init; }

        [Range(FoodProteinMinValue, FoodProteinMaxValue)]
        public double Protein { get; init; }

        [Range(FoodCarbsMinValue, FoodCarbsMaxValue)]
        public double Carbs { get; init; }

        [Range(FoodFatMinValue, FoodFatMaxValue)]
        public double Fat { get; init; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

    }
}
