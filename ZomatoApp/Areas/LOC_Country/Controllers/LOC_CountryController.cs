using Microsoft.AspNetCore.Mvc;
using System.Data;
using ZomatoApp.Areas.LOC_Country.Models;
using ZomatoApp.BAL;
using ZomatoApp.Dal.CountryDAL;

namespace ZomatoApp.Areas.LOC_Country.Controllers
{
    [CheackAccess]
    [Area("LOC_Country")]
    public class LOC_CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        LOC_Country_DAL dal_LOC_Country = new LOC_Country_DAL();

        public IActionResult CountryList()
        {

            DataTable dt = dal_LOC_Country.dbo_PR_LOC_Country_SelectAll();

            return View(dt);

        }

        public IActionResult AddEditCountry(int CountryID)
        {
            if(CountryID != null && CountryID > 0)
            {
                DataTable dt = dal_LOC_Country.dbo_PR_LOC_Country_SelectByPK(CountryID);

                LOC_CountryModel model_LOC_Country = new LOC_CountryModel();

                foreach(DataRow dr in dt.Rows)
                {
                    model_LOC_Country.CountryID = Convert.ToInt32(dr["CountryID"]);
                    model_LOC_Country.CountryName = dr["CountryName"].ToString();

                }

                return View(model_LOC_Country);

            }

            return View();

        }

        public IActionResult SaveCountry(LOC_CountryModel model_LOC_Country)
        {
            if(model_LOC_Country.CountryID == 0)
            {
                DataTable dt = dal_LOC_Country.dbo_PR_LOC_Country_Insert(model_LOC_Country.CountryName);
                TempData["Data"] = "Record Inserted Successfully";
            }
            else
            {
                DataTable dt = dal_LOC_Country.dbo_PR_LOC_Country_Update(model_LOC_Country.CountryID, model_LOC_Country.CountryName);
                TempData["Data"] = "Record Update Successfully";
            }

            return RedirectToAction("CountryList");
        }

        public IActionResult DeleteCountry(int CountryID)
        {
            if (Convert.ToBoolean(dal_LOC_Country.dbo_PR_LOC_Country_Delete(CountryID)))
            {
                TempData["Data"] = "Record Deleted Successfully";
                return RedirectToAction("CountryList");
            }

            return RedirectToAction("CountryList");
        }

    }
}
