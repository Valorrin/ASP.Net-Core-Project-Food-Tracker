using System.ComponentModel.DataAnnotations;

using static FoodTracker.Data.DataConstants.Food;

namespace FoodTracker.Data.Models
{
    public class Food
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; init; }

        [Range(GramsMinValue, GramsMaxValue)]
        public double Grams { get; init; }

        [Range(CaloriesMinValue, CaloriesMaxValue)]
        public double Calories { get; init; }

        [Range(ProteinMinValue, ProteinMaxValue)]
        public double Protein { get; init; }

        [Range(CarbsMinValue, CarbsMaxValue)]
        public double Carbs { get; init; }

        [Range(FatMinValue, FatMaxValue)]
        public double Fat { get; init; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

    }
}
