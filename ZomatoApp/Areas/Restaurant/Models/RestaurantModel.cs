namespace ZomatoApp.Areas.Restaurant.Models
{
    public class RestaurantModel
    {
        public int RestaurantID {   get; set; }

        public string RestaurantName { get; set; }

        public IFormFile File { get; set; }

        public string RestaurantImage { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public decimal Rating { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }

        public bool IsActive { get; set; }

        public int CityID { get; set; }

        public string CityName { get; set; }

        public string FoodType { get; set; }

        public bool IsFavourate { get; set; }

    }
}
