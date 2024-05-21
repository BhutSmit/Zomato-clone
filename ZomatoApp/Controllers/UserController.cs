using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Data;
using ZomatoApp.Areas.Food.Models;
using ZomatoApp.Areas.FoodType.Models;
using ZomatoApp.Areas.Restaurant.Models;
using ZomatoApp.Dal;
using ZomatoApp.Dal.User;
using ZomatoApp.Models;

namespace ZomatoApp.Controllers
{
    public class UserController : Controller
    {
        Restaurant_DAL dal_Restaurant = new Restaurant_DAL();
        FoodType_DAL dal_FoodType = new FoodType_DAL();
        Food_DAL dal_Food = new Food_DAL();
        User_DAL dal_User = new User_DAL();
        public IActionResult Index()
        {
            DataTable dt = dal_Restaurant.dbo_PR_Restaurant_SelectAll();
            DataTable dt2 = dal_User.dbo_PR_Restaurant_SelectAll_ByCityList();

            ViewBag.dt2 = dt2;

            return View(dt);
        }

        public IActionResult Favourate()
        {
            DataTable dtRestaurant = dal_User.dbo_PR_Restaurant_SelectAllFavourate();

            List<RestaurantModel> favourateRestaurantList = new List<RestaurantModel>();

            foreach (DataRow dr in dtRestaurant.Rows)
            {
                RestaurantModel model_Restaurant = new RestaurantModel();
                model_Restaurant.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                model_Restaurant.RestaurantName = dr["RestaurantName"].ToString();
                model_Restaurant.RestaurantImage = dr["RestaurantImage"].ToString();
                model_Restaurant.Rating = Convert.ToDecimal(dr["Rating"]);
                model_Restaurant.IsFavourate = Convert.ToBoolean(dr["IsFavourate"]);
                model_Restaurant.CityName = dr["CityName"].ToString();
                model_Restaurant.OpeningTime = Convert.ToDateTime(dr["OpeningTime"]);
                model_Restaurant.ClosingTime = Convert.ToDateTime(dr["ClosingTime"]);
                favourateRestaurantList.Add(model_Restaurant);
            }

            //ViewBag.FavourateRestaurantList = favourateRestaurantList;

            DataTable dtFoodType = dal_User.dbo_PR_FoodType_SelectAllFavourate();

            List<FoodTypeModel> favourateFoodTypeList = new List<FoodTypeModel>();

            foreach (DataRow dr in dtFoodType.Rows)
            {
                FoodTypeModel model_FoodType = new FoodTypeModel();
                model_FoodType.FoodTypeID = Convert.ToInt32(dr["FoodTypeID"]);
                model_FoodType.FoodTypeName = dr["FoodTypeName"].ToString();
                model_FoodType.FoodTypeImage = dr["FoodTypeImage"].ToString();
                model_FoodType.IsFavourate = Convert.ToBoolean(dr["IsFavourate"]);
                favourateFoodTypeList.Add(model_FoodType);
            }

            //ViewBag.FavourateFoodTypeList = favourateFoodTypeList;

            DataTable dtFood = dal_User.dbo_PR_MST_Food_SelectAllFavourate();

            List<FoodModel> favourateFoodList = new List<FoodModel>();

            foreach (DataRow dr in dtFood.Rows)
            {
                FoodModel model_Food = new FoodModel();
                model_Food.FoodID = Convert.ToInt32(dr["FoodID"]);
                model_Food.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                model_Food.FoodName = dr["FoodName"].ToString();
                model_Food.Description = dr["Description"].ToString();
                model_Food.Price = Convert.ToDecimal(dr["Price"]);
                model_Food.IsVegiterian = Convert.ToBoolean(dr["IsFavourate"]);
                model_Food.FoodImage = dr["FoodImage"].ToString();
                model_Food.FoodTypeID = Convert.ToInt32(dr["FoodTypeID"]);
                model_Food.IsActive = Convert.ToBoolean(dr["IsActive"]);
                model_Food.Review = Convert.ToDecimal(dr["Review"]);
                model_Food.IsFavourate = Convert.ToBoolean(dr["IsFavourate"]);
                favourateFoodList.Add(model_Food);

            }

            //ViewBag.FavourateFoodTypeList = favourateFoodTypeList;

            var viewModel = new FavourateViewModel
            {
                FavourateRestaurantList = favourateRestaurantList,
                FavourateFoodTypeList = favourateFoodTypeList,
                FavourateFoodList = favourateFoodList
            };
            return View(viewModel);
        }

        public IActionResult FavourateRestaurantList()
        {

            return RedirectToAction("Favourate");
        }

        public IActionResult ChangeFavourate(int RestaurantID, bool IsFavourate)
        {
            DataTable dt = dal_User.dbo_PR_Restaurant_Favourate(RestaurantID, IsFavourate);

            return RedirectToAction("Index", dt);
        }

        public IActionResult UserRestaurantWiseFoodType(int RestaurantID, string RestaurantName, string Address, string OpeningTime, string ClosingTime)
        {
            HttpContext.Session.SetInt32("RestaurantID", RestaurantID);
            HttpContext.Session.SetString("RestaurantName", RestaurantName);
            HttpContext.Session.SetString("Address", Address);
            HttpContext.Session.SetString("OpeningTime", OpeningTime);
            HttpContext.Session.SetString("ClosingTime", ClosingTime);
            DataTable dt = dal_FoodType.dbo_PR_RestaurentWiseFoodtype(RestaurantID);

            return View(dt);
        }

        public IActionResult UserFoodTypeWiseFood(int FoodTypeID, int RestaurantID)
        {
            HttpContext.Session.SetInt32("FoodTypeID", FoodTypeID);
            DataTable dt = dal_Food.dbo_PR_FoodTypeWiseFood(FoodTypeID);


            return View(dt);
        }

        public IActionResult Cart()
        {
            DataTable dt = dal_User.dbo_PR_Cart_SelectAll();

            //ViewBag.CartItemList = dt;
            //Console.WriteLine("Hello");
            //Console.WriteLine(dt);

            List<MST_OrderModel> MST_OrderList = new List<MST_OrderModel>();

            foreach(DataRow dr in dt.Rows)
            {
                MST_OrderModel model_MST_Order = new MST_OrderModel();

                model_MST_Order.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                model_MST_Order.FoodTypeID = Convert.ToInt32(dr["FoodTypeID"]);
                model_MST_Order.FoodID = Convert.ToInt32(dr["FoodID"]);
                model_MST_Order.Quantity = Convert.ToInt32(dr["Quantity"]);
                model_MST_Order.Amount = Convert.ToInt32(dr["Price"]);
                MST_OrderList.Add(model_MST_Order);
                
            }


            //ViewBag.CartItemList = MST_OrderList;

            var viewModel = new MST_CartItemListViewModel
            {
                cartItemList = MST_OrderList
            };

            return View(dt);
        }

        public IActionResult CartInsert(int FoodID)
        {
            DataTable FoodItemInCart = dal_User.dbo_PR_Cart_SelectByFoodID(FoodID);

            if (FoodItemInCart.Rows.Count <= 0)
            {
                DataTable dt = dal_User.dbo_PR_Cart_Insert(FoodID);
                TempData["CartItem"] = "Added In Cart";
            }
            else
            {
                TempData["CartItem"] = "Aleardy";
            }

            return RedirectToAction("UserFoodTypeWiseFood", new {RestaurantID = HttpContext.Session.GetInt32("RestaurantID"), FoodTypeID = HttpContext.Session.GetInt32("FoodTypeID")});
        }

        public IActionResult CartDelete(int CartID)
        {
            if (Convert.ToBoolean(dal_User.dbo_PR_Cart_Delete(CartID))){

                TempData["CartItem"] = "Delete";
                return RedirectToAction("Cart");
            }

            TempData["CartItem"] = "Not Deleted";

            return RedirectToAction("Cart");
        }

        public IActionResult MST_Order()
        {
            DataTable dt = dal_User.dbo_PR_MST_Order_SelectAll();

            return View(dt);
        }

        public IActionResult Cart_Update(int CartID, int FoodID, int Quantity)
        {
            DataTable dt = dal_User.dbo_PR_Cart_Update(CartID, FoodID, Quantity);

            TempData["CartItem"] = "Update";

            return RedirectToAction("Cart");
        }

        public IActionResult MST_OrderDetail(int RestaurantID, int FoodTypeID, int FoodID)
        {

            DataTable dt = dal_Food.dbo_PR_Food_SelectByPK(FoodID);
            MST_OrderModel model_MST_Order = new MST_OrderModel();

            foreach(DataRow dr in dt.Rows)
            {

                model_MST_Order.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                model_MST_Order.FoodTypeID = Convert.ToInt32(dr["FoodTypeID"]);
                model_MST_Order.FoodID = Convert.ToInt32(dr["FoodID"]);
                model_MST_Order.Amount = Convert.ToInt32(dr["Price"]);
                model_MST_Order.Description = dr["Description"].ToString();
                model_MST_Order.Review = Convert.ToDecimal(dr["Review"]);
                model_MST_Order.IsActive = Convert.ToBoolean(dr["IsActive"]);

            }

            return View(model_MST_Order);
        }

        public IActionResult MST_OrderDetail2()
        {
            return View();
        }

        public IActionResult MST_Order_Insert(int RestaurantID, int FoodTypeID, int FoodID, int Quantity, string Address)
        {
            int Price = 100;
            int Amount = Price;
            int TotalAmount = Amount * Quantity;
            DataTable dt = dal_User.dbo_PR_MST_Order_Insert(RestaurantID, FoodTypeID, FoodID, Quantity, Amount, TotalAmount, Address);

            return RedirectToAction("MST_Order");
        }

        public IActionResult MST_CartOrder(string Address)
        {
            //Console.WriteLine(ViewBag.CartItemList);
            MST_OrderModel model_MST_User = new MST_OrderModel();

            DataTable dt1 = dal_User.dbo_PR_Cart_SelectAll();

            foreach(DataRow dr in dt1.Rows)
            {
                int TotalAmount = Convert.ToInt32(dr["Quantity"]) * Convert.ToInt32(dr["Price"]);

                DataTable dt = dal_User.dbo_PR_MST_Order_Insert(Convert.ToInt32(dr["RestaurantID"]), Convert.ToInt32(dr["FoodTypeID"]), Convert.ToInt32(dr["FoodID"]), Convert.ToInt32(dr["Quantity"]), Convert.ToInt32(dr["Price"]), TotalAmount, Address);
            }

            return RedirectToAction("MST_Order");
        }

        public ActionResult CartOrderDetail()
        {
            string selectedCartItemIds = Request.Form["selectedCartItemIds"];

            string[] SelectedCartItemID = selectedCartItemIds.Split(',', StringSplitOptions.RemoveEmptyEntries);

            List<int> CartID = new List<int>();

            foreach (string id in SelectedCartItemID)
            {
                if (int.TryParse(id, out int CartItemID))
                {
                    CartID.Add(CartItemID);
                }
                else
                {
                    Console.WriteLine("Invalid " + CartItemID);
                }
            }



            if (selectedCartItemIds != null && selectedCartItemIds.Length > 0)
            {
                Console.WriteLine("Selected Restaurant IDs: " + string.Join(", ", selectedCartItemIds));

                foreach (int id in CartID)
                {
                    Console.WriteLine(id);
                }

                return RedirectToAction("MST_Order");
            }

            ModelState.AddModelError("", "No restaurants selected for deletion.");
            return View();
        }

        public IActionResult CancleOrder(int OrderID)
        {
            if (Convert.ToBoolean(dal_User.dbo_PR_MST_Order_Delete(OrderID)))
            {
                return RedirectToAction("MST_Order");
            }

            return RedirectToAction("MST_Order");
        }

        public IActionResult RestaurantByCityName(string CityName)
        {
            DataTable dt = dal_User.dbo_PR_Restaurant_SelectAll_ByCityName(CityName);

            return View(dt);
        }
    }
}
