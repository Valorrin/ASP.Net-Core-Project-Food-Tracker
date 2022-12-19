using System.ComponentModel.DataAnnotations;

using static FoodTracker.Data.DataConstants.Food;

namespace FoodTracker.Models.Food
{
    public class AddFoodFormModel
    {
        [Required(ErrorMessage = "Please enter a food name")]
        [StringLength(
            NameMaxLength, 
            MinimumLength = NameMinLength,
            ErrorMessage = "The name must be between {2} and {1} characters.")]
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

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        [Display(Name = "trash")]
        public IEnumerable<FoodCategoryViewModel>? Categories { get; set; }
    }
}
