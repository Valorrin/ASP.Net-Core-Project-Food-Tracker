﻿using System.ComponentModel.DataAnnotations;

using static FoodTracker.Data.DataConstants;

namespace FoodTracker.Data.Models
{
    public class Food
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(FoodNameMaxLength)]
        public string Name { get; init; }

        [Range(FoodCaloriesMinLength, FoodCaloriesMaxLength)]
        public double Calories { get; init; }

        [Range(FoodProteinMinLength, FoodProteinMaxLength)]
        public double Protein { get; init; }

        [Range(FoodCarbsMinLength, FoodCarbsMaxLength)]
        public double Carbs { get; init; }

        [Range(FoodFatMinLength, FoodFatMaxLength)]
        public double Fat { get; init; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

    }
}
