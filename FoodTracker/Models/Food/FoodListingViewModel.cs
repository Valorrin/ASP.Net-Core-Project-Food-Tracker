﻿
namespace FoodTracker.Models.Food
{
    public class FoodListingViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Grams { get; set; }

        public double Calories { get; set; }

        public double Protein { get; set; }

        public double Carbs { get; set; }

        public double Fat { get; set; }
    }
}