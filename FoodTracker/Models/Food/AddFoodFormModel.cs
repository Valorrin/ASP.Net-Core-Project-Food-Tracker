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

        [Range(FoodCaloriesMinLength, FoodCaloriesMaxLength)]
        public double Calories { get; init; }

        [Range(FoodProteinMinLength, FoodProteinMaxLength)]
        public double Protein { get; init; }

        [Range(FoodCarbsMinLength, FoodCarbsMaxLength)]
        public double Carbs { get; init; }

        [Range(FoodFatMinLength, FoodFatMaxLength)]
        public double Fat { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        [Display(Name = "trash")]
        public IEnumerable<FoodCategoryViewModel>? Categories { get; set; }
    }
}
