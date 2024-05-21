using ZomatoApp.Areas.Food.Models;
using ZomatoApp.Areas.FoodType.Models;
using ZomatoApp.Areas.Restaurant.Models;

namespace ZomatoApp.Models
{
    public class FavourateViewModel
    {
        public List<RestaurantModel> FavourateRestaurantList { get; set; }

        public List<FoodTypeModel> FavourateFoodTypeList { get; set; }

        public List<FoodModel> FavourateFoodList { get; set; }
    }
}
