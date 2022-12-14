using System.ComponentModel.DataAnnotations;

using static FoodTracker.Data.DataConstants;

namespace FoodTracker.Models.Food
{
    public class AddFoodFormModel
    {
        [Required(ErrorMessage = "Please enter a food name")]
        [StringLength(
            FoodNameMaxLength, 
            MinimumLength = FoodNameMinLength,
            ErrorMessage = "The name must be between {2} and {1} characters.")]
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

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        [Display(Name = "trash")]
        public IEnumerable<FoodCategoryViewModel>? Categories { get; set; }
    }
}
