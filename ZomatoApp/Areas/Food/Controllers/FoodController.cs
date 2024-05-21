using Microsoft.AspNetCore.Mvc;
using System.Data;
using ZomatoApp.Areas.Food.Models;
using ZomatoApp.BAL;
using ZomatoApp.Dal;

namespace ZomatoApp.Areas.Food.Controllers
{
    [CheackAccess]
    [Area("Food")]
    public class FoodController : Controller
    {
        Food_DAL food_DAL = new Food_DAL();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FoodTypeWiseFood(int FoodTypeID, int RestaurantID)
        {
            TempData["FoodTypeID"] = FoodTypeID;
            HttpContext.Session.SetInt32("FoodTypeID", FoodTypeID);
            TempData["myData"] = RestaurantID;
            DataTable dt = food_DAL.dbo_PR_FoodTypeWiseFood(FoodTypeID);

            return View(dt);
        }

        public IActionResult AddEditFood(int FoodID)
        {
            if (FoodID != null && FoodID > 0)
            {
                DataTable dt = food_DAL.dbo_PR_Food_SelectByPK(FoodID);

                FoodModel model_Food = new FoodModel();

                foreach (DataRow dr in dt.Rows)
                {
                    model_Food.FoodID = Convert.ToInt32(dr["FoodID"]);
                    model_Food.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    model_Food.FoodName = dr["FoodName"].ToString();
                    model_Food.Description = dr["Description"].ToString();
                    model_Food.Price = Convert.ToDecimal(dr["Price"]);
                    model_Food.IsVegiterian = Convert.ToBoolean(dr["isVegiterian"]);
                    model_Food.FoodImage = dr["FoodImage"].ToString();
                    model_Food.FoodTypeID = Convert.ToInt32(dr["FoodTypeID"]);
                    model_Food.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    model_Food.Review = Convert.ToDecimal(dr["Review"]);
                }

                return View(model_Food);
            }

            return View();
        }

        public IActionResult SaveFood(FoodModel modelFood)
        {
            int id = 0;
            var RestaurantID = HttpContext.Session.GetInt32("RestaurantID");
            var FoodTypeID = HttpContext.Session.GetInt32("FoodTypeID");
            if (modelFood.FoodID == 0)
            {
                id = Convert.ToInt32(TempData["myData"]);
                Console.WriteLine(RestaurantID);

                DataTable dt = food_DAL.dbo_PR_MST_Food_Insert(modelFood.FoodName, Convert.ToInt32(RestaurantID), modelFood.Description, modelFood.Price, modelFood.IsVegiterian, modelFood.FoodImage, Convert.ToInt32(FoodTypeID), modelFood.IsActive, modelFood.Review);
                Dictionary<String, String> data = new Dictionary<string, string>();

                //"type": "success",
                //    "message": "Record Inserted Successfully"
                TempData["Data"] = dt == null ? "Error" : "Record Inserted Successfully";
            }
            else
            {

                DataTable dt = food_DAL.dbo_PR_MST_Food_Update(modelFood.FoodID, Convert.ToInt32(RestaurantID), modelFood.FoodName, modelFood.Description, modelFood.Price, modelFood.IsVegiterian, modelFood.FoodImage, Convert.ToInt32(FoodTypeID), modelFood.IsActive, modelFood.Review);
                TempData["Data"] = dt == null ? "Error" : "Record Updated Successfully";
            }

            return RedirectToAction("FoodTypeWiseFood", new { FoodTypeID = Convert.ToInt32(FoodTypeID), RestaurantID = Convert.ToInt32(FoodTypeID) });
        }

        public IActionResult DeleteFood(int FoodID)
        {
            var RestaurantID = HttpContext.Session.GetInt32("RestaurantID");
            var FoodTypeID = HttpContext.Session.GetInt32("FoodTypeID");

            if (Convert.ToBoolean(food_DAL.dbo_PR_MST_Food_Delete(FoodID)))
            {
                TempData["Data"] = "Record Deleted Successfully";
            }
            else
            {
                TempData["Data"] = "Error";
            }

            return RedirectToAction("FoodTypeWiseFood", new { FoodTypeID = Convert.ToInt32(FoodTypeID), RestaurantID = Convert.ToInt32(RestaurantID) });
        }

        public IActionResult FoodFilter(string? FoodName, decimal? Price, bool? IsVegiterian, bool? IsActive, decimal? Review, int SliderValue1, int SliderValue2)
        {
            var RestaurantID = HttpContext.Session.GetInt32("RestaurantID");
            var FoodTypeID = Convert.ToInt32(HttpContext.Session.GetInt32("FoodTypeID"));

            Console.WriteLine(FoodName);
            Console.WriteLine($"SliderValue1: {SliderValue1}, SliderValue2: {SliderValue2}");
            DataTable dt = food_DAL.dbo_PR_MST_Food_Filter(Convert.ToInt32(RestaurantID), Convert.ToInt32(FoodTypeID), FoodName, Price, SliderValue1, SliderValue2, IsVegiterian, IsActive, Review);
            return View("FoodTypeWiseFood", dt);
        }
    }
}
