using Microsoft.AspNetCore.Mvc;
using System.Data;
using ZomatoApp.Areas.FoodType.Models;
using ZomatoApp.BAL;
using ZomatoApp.Dal;


namespace ZomatoApp.Areas.FoodType.Controllers
{
    [CheackAccess]
    [Area("FoodType")]

    public class FoodTypeController : Controller
    {
        FoodType_DAL foodType_DAL = new FoodType_DAL();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RestaurantWiseFoodType(int RestaurantID)
        {
            TempData["RestaurantID"] = RestaurantID;
            TempData.Keep();
            HttpContext.Session.SetInt32("RestaurantID", RestaurantID);
            var RID = HttpContext.Session.GetInt32("RestaurantID");
            Console.WriteLine(TempData["RestaurantID"].ToString());
            
            DataTable dt = foodType_DAL.dbo_PR_RestaurentWiseFoodtype(Convert.ToInt32(RID));

            return View(dt);
        }

        public IActionResult AddEditFoodType(int FoodTypeID)
        {
            if(FoodTypeID != null && FoodTypeID > 0)
            {
                DataTable dt = foodType_DAL.dbo_PR_FoodType_SelectByPK(FoodTypeID);

                FoodTypeModel model_FoodType = new FoodTypeModel();

                foreach(DataRow dr in dt.Rows)
                {
                    model_FoodType.FoodTypeID = Convert.ToInt32(dr["FoodTypeID"]);
                    model_FoodType.FoodTypeName = dr["FoodTypeName"].ToString();
                    model_FoodType.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    model_FoodType.FoodTypeImage = dr["FoodTypeImage"].ToString();
                }

                return View(model_FoodType);
            }

            return View();
        }

        public IActionResult SaveFoodType(FoodTypeModel modelFoodType)
        {
            if(modelFoodType.FoodTypeID == 0)
            {
                DataTable dt = foodType_DAL.dbo_PR_FoodType_Insert(modelFoodType.FoodTypeName, Convert.ToInt32(TempData["RestaurantID"]), modelFoodType.FoodTypeImage);
                TempData["Data"] = "Record Inserted Successfully";
            }
            else
            {
                DataTable dt = foodType_DAL.dbo_PR_FoodType_Update(modelFoodType.FoodTypeID, modelFoodType.FoodTypeName, Convert.ToInt32(TempData["RestaurantID"]), modelFoodType.FoodTypeImage);
                TempData["Data"] = "Record Update Successfully";
            }

            return RedirectToAction("RestaurantWiseFoodType", new {RestaurantID = TempData["RestaurantID"] });
        }

        public IActionResult DeleteFoodType(int FoodTypeID)
        {
            if (Convert.ToBoolean(foodType_DAL.dbo_PR_FoodType_Delete(FoodTypeID)))
            {
                TempData["Data"] = "Record Deleted Successfully";
                return RedirectToAction("RestaurantWiseFoodType", new {RestaurantID = TempData["RestaurantID"] });
            }

            return RedirectToAction("RestaurantWiseFoodType");
        }

        public IActionResult FoodTypeFilter(string? FoodTypeName)
        {
            DataTable dt = foodType_DAL.dbo_PR_FoodType_Filter(FoodTypeName);
            return View("RestaurantWiseFoodType", dt);
        }
    }
}
