using Microsoft.AspNetCore.Mvc;
using System.Data;
using ZomatoApp.Areas.LOC_City.Models;
using ZomatoApp.Areas.LOC_State.Models;
using ZomatoApp.Areas.MST_User.Models;
using ZomatoApp.Dal;
using ZomatoApp.Dal.CityDAL;
using ZomatoApp.Dal.StateDAL;

namespace ZomatoApp.Areas.MST_User.Controllers
{
    [Area("MST_User")]
    public class MST_UserController : Controller
    {
        MST_User_DAL MST_User_DAL = new MST_User_DAL();
        LOC_State_DAL dal_LOC_State = new LOC_State_DAL();
        LOC_City_DAL dal_LOC_City = new LOC_City_DAL();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginForm()
        {
            return View("LoginForm");
        }

        [HttpPost]
        public IActionResult LoginUser(MST_UserModel modelMST_User)
        {

            if(modelMST_User.UserName == null)
            {
                TempData["UserNameError"] = "User Name Is Required";
            }
            if(modelMST_User.Password == null)
            {
                TempData["PasswordError"] = "Password Is Required";
            }

            //if(modelMST_User.UserName != null || modelMST_User.Password != null)
            //{
            //    return RedirectToAction("LoginForm", "MST_User");
            //}
   
            else
            {
                DataTable dt = MST_User_DAL.dbo_PR_MST_User_SelectByUserNameAndPassword(modelMST_User.UserName, modelMST_User.Password);
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        HttpContext.Session.SetString("FirstName", dr["FirstName"].ToString());
                        HttpContext.Session.SetString("LastName", dr["LastName"].ToString());
                        HttpContext.Session.SetString("Email", dr["Email"].ToString());
                        HttpContext.Session.SetString("IsAdmin", dr["IsAdmin"].ToString());
                        HttpContext.Session.SetString("IsActive", dr["IsActive"].ToString());
                        break;

                    }
                }
                else
                {
                    TempData["Error"] = "User Name And Password Is Invalid";
                    return RedirectToAction("LoginForm", "MST_User");
                }

                if(HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null && HttpContext.Session.GetString("IsAdmin") == "True")
                {
                    //Console.WriteLine(HttpContext.Session.GetString("UserName"));
                    return RedirectToAction("Index", "Home", new {area = ""});
                }
                else if(HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index", "User", new {area = ""});
                }
            }

            return RedirectToAction("LoginForm", "MST_User", new {area = "MST_User"});
        }

        public IActionResult LogOutUser()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginForm", "MST_User");
        }

        public IActionResult SignUpForm()
        {
            ViewBag.CountryList = dal_LOC_State.dbo_PR_LOC_Country_ComboBox();
            ViewBag.StateList = dal_LOC_City.dbo_PR_LOC_StateComboBox();
            ViewBag.CityList = dal_LOC_City.dbo_PR_LOC_City_ComboBox();
            return View();
        }

        [HttpPost]
        public IActionResult Register(MST_UserModel modelMST_User)
        {
            //if(modelMST_User.UserName == null)
            //{
            //    TempData["UserNameError"] = "User Name Is Required";
            //}
            //if(modelMST_User.Password == null)
            //{
            //    TempData["PasswordError"] = "Password Is Required";
            //}
            //if(modelMST_User.FirstName == null)
            //{
            //    TempData["FirstNameError"] = "First Name Is Required";
            //}
            //if(modelMST_User.LastName == null)
            //{
            //    TempData["LastNameError"] = "Last Name Is Required";
            //}
            //if(modelMST_User.Email == null)
            //{
            //    TempData["EmailError"] = "Email Address Is Required";
            //}
            //if(modelMST_User.CityID == null)
            //{
            //    TempData["CityIDError"] = "City ID Is Required";
            //}
            //if(modelMST_User.Gender == null)
            //{
            //    TempData["GenderError"] = "Gender Is Required";
            //}
            //if(modelMST_User.BirthDate == null)
            //{
            //    TempData["BirthDateError"] = "BirthDate Is Required";
            //}
            //if(modelMST_User.PhoneNo == null)
            //{
            //    TempData["PhoneNoError"] = "PhoneNo Is Required";
            //}
            //if(modelMST_User.IsAdmin == null)
            //{
            //    TempData["IsAdminError"] = "Admin Is Required";
            //}
            //if(modelMST_User.IsActive == null)
            //{
            //    TempData["IsActive"] = "Active Is Required";
            //}
            //if (TempData["UserNameError"] != null || TempData["PasswordError"] != null || TempData["FirstNameError"] != null || TempData["LastNameError"] != null || TempData["EmailError"] != null || TempData["CityIDError"] != null || TempData["GenderError"] != null || TempData["BirthDateError"] != null || TempData["PhoneNoError"] != null || TempData["IsAdminError"] != null || TempData["IsActive"] != null)
            //{
            //    return RedirectToAction("LoginForm", "MST_User", new {area = "MST_User"});
            //}
            //else
            //{
                bool IsSuccess = MST_User_DAL.dbo_PR_MST_User_Insert(modelMST_User.UserName, modelMST_User.Password, modelMST_User.Email, modelMST_User.FirstName, modelMST_User.LastName, modelMST_User.PhoneNo, modelMST_User.BirthDate, modelMST_User.Gender, false, true, modelMST_User.CityID);
                if(IsSuccess)
                {
                    return RedirectToAction("LoginForm", "MST_User", new { area = "MST_User" });
                }
                else
                {
                    return RedirectToAction("SignUpForm", "MST_User", new { area = "MST_User" });
                }

            //}

        }

        public IActionResult CityForComboBox(int StateID)
        {
            List<LOC_CityDropDownModel> list = dal_LOC_City.dbo_PR_LOC_City_SelectByStateID(StateID);

            return Json(list);
        }


    }
}
