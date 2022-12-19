namespace FoodTracker.Data
{
    public class DataConstants
    {
        public class Food
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const int CaloriesMinValue = 1;
            public const int CaloriesMaxValue = 45000;

            public const int ProteinMinValue = 1;
            public const int ProteinMaxValue = 20000;

            public const int CarbsMinValue = 1;
            public const int CarbsMaxValue = 20000;

            public const int FatMinValue = 1;
            public const int FatMaxValue = 45000;

            public const int GramsMinValue = 1;
            public const int GramsMaxValue = 5000;
        }

        public class Category
        {
            public const int NameMaxLength = 10;
        }
    }
}
