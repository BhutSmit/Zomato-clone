using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ZomatoApp.BAL
{
	public class CheackAccess : ActionFilterAttribute, IAuthorizationFilter
	{
		//When User ID is not availale or removed from session,it will redirect to login page
		public void OnAuthorization(AuthorizationFilterContext filterContext)
		{
			if (filterContext.HttpContext.Session.GetString("UserID") == null)
				filterContext.Result = new RedirectResult("~/MST_User/MST_User/LoginForm");

			if(filterContext.HttpContext.Session.GetString("UserID") != null && !Convert.ToBoolean(filterContext.HttpContext.Session.GetString("IsAdmin")))
			{
				filterContext.Result = new UnauthorizedResult();
			}

		}
		// Once we logout (session is cleared) then we can not go back to the
		//previous screen
		// We must login to proceed further.
		public override void OnResultExecuting(ResultExecutingContext context)
		{
			//context.HttpContext.Response.Headers["Cache-Control"] = "no-cache,no - store, must - revalidate";
			//context.HttpContext.Response.Headers["Expires"] = "-1";
			//context.HttpContext.Response.Headers["Pragma"] = "no-cache";
			base.OnResultExecuting(context);
		}
	}
}
