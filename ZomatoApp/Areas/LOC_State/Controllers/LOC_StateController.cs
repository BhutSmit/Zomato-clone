using Microsoft.AspNetCore.Mvc;
using System.Data;
using ZomatoApp.Areas.LOC_State.Models;
using ZomatoApp.BAL;
using ZomatoApp.Dal.StateDAL;

namespace ZomatoApp.Areas.LOC_State.Controllers
{
    [CheackAccess]
    [Area("LOC_State")]
    public class LOC_StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        LOC_State_DAL dal_LOC_State = new LOC_State_DAL();

        public IActionResult StateList()
        {

            DataTable dt = dal_LOC_State.dbo_PR_LOC_State_SelectAll();

            return View(dt);
            
        }

        public IActionResult AddEditState(int StateID)
        {
            ViewBag.CountryList = dal_LOC_State.dbo_PR_LOC_Country_ComboBox();
            if(StateID != null &&  StateID > 0)
            {
                DataTable dt = dal_LOC_State.dbo_PR_LOC_State_SelectByPK(StateID);

                LOC_StateModel model_LOC_State = new LOC_StateModel();

                foreach(DataRow dr in dt.Rows)
                {
                    model_LOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                    model_LOC_State.StateName = dr["StateName"].ToString();
                    model_LOC_State.CountryID = Convert.ToInt32(dr["CountryID"]);
                }

                return View(model_LOC_State);
            }

            return View();
        }

        public IActionResult SaveState(LOC_StateModel model_LOC_State)
        {
            if(model_LOC_State.StateID == 0)
            {
                DataTable dt = dal_LOC_State.dbo_PR_LOC_State_Insert(model_LOC_State.StateName, model_LOC_State.CountryID);
                TempData["Data"] = "Record Insert Successfully";
            }
            else
            {
                DataTable dt = dal_LOC_State.dbo_PR_LOC_State_Update(model_LOC_State.StateID, model_LOC_State.StateName, model_LOC_State.CountryID);
                TempData["Data"] = "Record Update Successfully";
            }

            return RedirectToAction("StateList");
        }

        public IActionResult DeleteState(int StateID)
        {
            if (Convert.ToBoolean(dal_LOC_State.dbo_PR_LOC_State_Delete(StateID)))
            {
                TempData["Data"] = "Record Deleted Successfully";
                return RedirectToAction("StateList");
            }

            return RedirectToAction("StateList");
        }

    }
}
