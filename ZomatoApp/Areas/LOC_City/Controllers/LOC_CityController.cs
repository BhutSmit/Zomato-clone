using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ZomatoApp.Areas.LOC_City.Models;
using ZomatoApp.Areas.LOC_State.Models;
using ZomatoApp.BAL;
using ZomatoApp.Dal.CityDAL;
using ZomatoApp.Dal.StateDAL;

namespace ZomatoApp.Areas.LOC_City.Controllers
{
   //[CheackAccess]
    [Area("LOC_City")]
    [Route("LOC_City/[controller]/[action]")]
    public class LOC_CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        LOC_City_DAL dal_LOC_City = new LOC_City_DAL();
        LOC_State_DAL dal_LOC_State = new LOC_State_DAL();

        public IActionResult CityList()
        {

            DataTable dt = dal_LOC_City.dbo_PR_LOC_City_SelectAll();

            return View(dt);
            
        }

        public IActionResult AddEditCity(int CityID)
        {
            ViewBag.CountryList = dal_LOC_State.dbo_PR_LOC_Country_ComboBox();
            ViewBag.StateList = dal_LOC_City.dbo_PR_LOC_StateComboBox();

            if(CityID != null && CityID > 0)
            {
                DataTable dt = dal_LOC_City.dbo_PR_LOC_City_SelectByPK(CityID);

                LOC_CityModel model_LOC_City = new LOC_CityModel();

                foreach(DataRow dr in dt.Rows)
                {
                    model_LOC_City.CityID = Convert.ToInt32(dr["CityID"]);
                    model_LOC_City.CityName = dr["CityName"].ToString();
                    model_LOC_City.StateID = Convert.ToInt32(dr["StateID"]);
                    model_LOC_City.CountryID = Convert.ToInt32(dr["CountryID"]);
                }

                //ViewBag.CountryList = dal_LOC_City.dbo_PR_LOC_State_ComboBox()

                return View(model_LOC_City);
            }

            return View();
        }

        public IActionResult SaveCity(LOC_CityModel model_LOC_City)
        {
            if(model_LOC_City.CityID == 0)
            {
                DataTable dt = dal_LOC_City.dbo_PR_LOC_City_Insert(model_LOC_City.CityName, model_LOC_City.StateID, model_LOC_City.CountryID);
                TempData["Data"] = "Record Insert Successfully";
            }
            else
            {
                DataTable dt = dal_LOC_City.dbo_PR_LOC_City_Update(model_LOC_City.CityID, model_LOC_City.CityName, model_LOC_City.StateID, model_LOC_City.CountryID);
                TempData["Data"] = "Record Update Successfully";
            }

            return RedirectToAction("CityList");
        }

        public IActionResult DeleteCity(int CityID)
        {
            if (Convert.ToBoolean(dal_LOC_City.dbo_PR_LOC_City_Delete(CityID)))
            {
                TempData["Data"] = "Record Deleted Successfully";
                return RedirectToAction("CityList");
            }
            return RedirectToAction("CityList");
        }

        [AllowAnonymous]
        public dynamic StatesForComboBox(int CountryID)
        {
            List<LOC_StateDropDownModel> list = dal_LOC_City.dbo_PR_LOC_StateByCountryID(CountryID);
            ViewBag.StateList = list;

            return Json(list);
        }
    }
}
