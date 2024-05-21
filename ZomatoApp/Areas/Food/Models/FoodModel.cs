namespace ZomatoApp.Areas.Food.Models
{
    public class FoodModel
    {

        public int FoodID { get; set; }

        public int RestaurantID { get; set; }

        public string FoodName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsVegiterian { get; set; }

        public string FoodImage { get; set; }

        public int FoodTypeID { get; set; }

        public bool IsActive { get; set; }

        public decimal Review { get; set; }

        public bool IsFavourate { get; set; }

        public int[] currentValues { get; set; }

    }
}
