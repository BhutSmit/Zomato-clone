namespace ZomatoApp.Areas.FoodType.Models
{
    public class FoodTypeModel
    {
        public int FoodTypeID { get; set; }

        public string FoodTypeName { get; set; }

        public int RestaurantID { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string FoodTypeImage { get; set; }

        public bool IsFavourate { get; set; }
    }
}
