using System.ComponentModel.DataAnnotations; 

namespace FoodTracker.Data.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.FoodNameMaxLength)]
        public string Name { get; set; }

        public double Calories { get; set; }

        public double Protein { get; set; }

        public double Carbs { get; set; }

        public double Fat { get; set; }


    }
}
