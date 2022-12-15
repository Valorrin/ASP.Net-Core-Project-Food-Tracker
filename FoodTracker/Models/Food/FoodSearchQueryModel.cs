﻿namespace FoodTracker.Models.Food
{
    public class FoodSearchQueryModel
    {
        public IEnumerable<string> Names { get; set; }

        public string SearchTerm { get; set; }

        public FoodSorting Sorting {get; set;}

        public IEnumerable<FoodListingViewModel> Foods { get; set; }
    }
}