using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing.Drawing2D;
using ZomatoApp.Areas.Restaurant.Models;
using ZomatoApp.BAL;
using ZomatoApp.Dal;
using ZomatoApp.Dal.OrderDAL;

namespace ZomatoApp.Areas.Restaurant.Controllers
{

    [CheackAccess]
    [Area("Restaurant")]
    public class RestaurantController : Controller
    {

        Restaurant_DAL restaurant_DAL = new Restaurant_DAL();
        MST_OrderDAL dal_MST_Order = new MST_OrderDAL();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RestaurantList()
        {
            Restaurant_DAL restaurant_DAL = new Restaurant_DAL();
            DataTable dt = restaurant_DAL.dbo_PR_Restaurant_SelectAll();

            return View(dt);
        }

        public IActionResult AddEditRestaurant(int RestaurantID)
        {
            if (RestaurantID != null && RestaurantID > 0)
            {
                DataTable dt = restaurant_DAL.dbo_PR_Restaurant_SelectByPK(RestaurantID);

                RestaurantModel model_restaurant = new RestaurantModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model_restaurant.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    model_restaurant.RestaurantName = dr["RestaurantName"].ToString();
                    model_restaurant.RestaurantImage = dr["RestaurantImage"].ToString();
                    model_restaurant.Address = dr["Address"].ToString();
                    model_restaurant.PhoneNo = dr["PhoneNo"].ToString();
                    model_restaurant.Email = dr["Email"].ToString();
                    model_restaurant.Rating = Convert.ToDecimal(dr["Rating"]);
                    model_restaurant.OpeningTime = Convert.ToDateTime(dr["OpeningTime"]);
                    model_restaurant.ClosingTime = Convert.ToDateTime(dr["ClosingTime"]);
                    model_restaurant.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    model_restaurant.CityID = Convert.ToInt32(dr["CityID"]);
                }

                return View(model_restaurant);
            }
            return View();
        }

        public IActionResult SaveRestaurant(RestaurantModel modelRestaurant)
        {

            if (modelRestaurant.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileNameWithPath = Path.Combine(path, modelRestaurant.File.FileName);
                modelRestaurant.RestaurantImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelRestaurant.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelRestaurant.File.CopyTo(stream);
                }
            }

            if (modelRestaurant.RestaurantID == 0)
            {

                DataTable dt = restaurant_DAL.dbo_PR_Restaurant_Insert(modelRestaurant.RestaurantName, modelRestaurant.RestaurantImage, modelRestaurant.Address, modelRestaurant.PhoneNo, modelRestaurant.Email, modelRestaurant.Rating, modelRestaurant.OpeningTime, modelRestaurant.ClosingTime, modelRestaurant.IsActive, modelRestaurant.CityID);
                TempData["Data"] = "Record Inserted Successfully";
            }
            else
            {
                DataTable dt = restaurant_DAL.dbo_PR_Restaurant_Update(modelRestaurant.RestaurantID, modelRestaurant.RestaurantName, modelRestaurant.RestaurantImage, modelRestaurant.Address, modelRestaurant.PhoneNo, modelRestaurant.Email, modelRestaurant.Rating, modelRestaurant.OpeningTime, modelRestaurant.ClosingTime, modelRestaurant.IsActive, modelRestaurant.CityID);
                TempData["Data"] = "Record Update Successfully";
            }

            return RedirectToAction("RestaurantList");
        }

        public IActionResult DeleteRestaurant(int RestaurantID)
        {
            if (Convert.ToBoolean(restaurant_DAL.dbo_PR_Restaurant_Delete(RestaurantID)))
            {
                TempData["Data"] = "Record Deleted Successfully";
                return RedirectToAction("RestaurantList");
            }
            return RedirectToAction("RestaurantList");
        }

        public IActionResult RestaurantWiseFoodType(int RestaurantID)
        {
            DataTable dt = restaurant_DAL.dbo_PR_RestaurentWiseFoodtype(RestaurantID);

            return View(dt);
        }

        public IActionResult FoodTypeWiseFood(int FoodTypeID)
        {
            DataTable dt = restaurant_DAL.dbo_PR_FoodTypeWiseFood(FoodTypeID);

            return View(dt);
        }

        public IActionResult RestaurantFilter(string? RestaurantName, string Address, bool? IsActive)
        {
            //if (RestaurantName == null)
            //{
            //    RestaurantName = DBNull.Value.ToString();
            //}
            //if (Address == null)
            //{
            //    Address = DBNull.Value.ToString();
            //}
            //if(IsActive == null)
            //{
            //    IsActive = Convert.ToBoolean(DBNull.Value.ToString());
            //}
            DataTable dt = restaurant_DAL.dbo_PR_Restaurant_Filter(RestaurantName, Address, IsActive);

            return View("RestaurantList", dt);
        }

        public ActionResult DeleteSelected()
        {
            string selectedRestaurantIds = Request.Form["selectedRestaurantIds"];

            string[] selectedRestaurantID = selectedRestaurantIds.Split(',', StringSplitOptions.RemoveEmptyEntries);

            List<int> RestaurantID = new List<int>();

            foreach (string id in selectedRestaurantID)
            {
                if (int.TryParse(id, out int RID))
                {
                    RestaurantID.Add(RID);
                }
                else
                {
                    Console.WriteLine("Invalid " + RID);
                }
            }



            if (selectedRestaurantIds != null && selectedRestaurantIds.Length > 0)
            {
                Console.WriteLine("Selected Restaurant IDs: " + string.Join(", ", selectedRestaurantIds));

                foreach (int id in RestaurantID)
                {
                    Console.WriteLine(id);
                }

                return RedirectToAction("RestaurantList");
            }

            ModelState.AddModelError("", "No restaurants selected for deletion.");
            return View("RestaurantList");
        }

        public IActionResult OrderList(int RestaurantID)
        {
            ViewBag.StatusList = dal_MST_Order.dbo_PR_Status_Status();
            DataTable dt = dal_MST_Order.dbo_PR_MST_Order_RestaurantWiseOrder(RestaurantID);

            var chartData = dt.AsEnumerable()
                        .GroupBy(row => row.Field<DateTime>("Created").Date)
                        .Select(grp => new {
                            Date = grp.Key.ToString("yyyy-MM-dd"),
                            DayName = grp.Key.ToString("dddd"), 
                            TotalSales = grp.Sum(row => row.Field<Int32>("TotalAmount"))
                        })
                        .OrderBy(data => data.Date)
                        .ToList();

            ViewBag.ChartData = chartData;

            return View(dt);
        }

        public IActionResult UpdateStatus(int OrderID, int RestaurantID, int StatusID)
        {
            DataTable dt = dal_MST_Order.dbo_PR_MST_Order_Update_OrderStatus(OrderID, RestaurantID, StatusID);

            return RedirectToAction("OrderList", new { RestaurantID = RestaurantID });
        }

    }
}
