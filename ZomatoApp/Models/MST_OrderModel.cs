using System.Drawing.Printing;

namespace ZomatoApp.Models
{
    public class MST_OrderModel
    {
        public int OrderID { get; set; }

        public int RestaurantID { get; set; }

        public int FoodTypeID { get; set; }

        public int FoodID { get; set; }

        public int Quantity { get; set; }

        public int Amount { get; set; }

        public int TotalAmount { get; set; }

        public int StatusID { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public decimal Review { get; set; }

        public bool IsActive { get; set; }

    }
}
