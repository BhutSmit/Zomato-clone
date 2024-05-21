using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ZomatoApp
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AllowAdminExceptUserAttribute : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext contex)
        {
            var user = contex.HttpContext.User;

            Console.WriteLine(user);

            if (!user.Identity.IsAuthenticated)
            {
                contex.Result = new UnauthorizedResult();
                return;
            }

            if (!Convert.ToBoolean(user.IsInRole("IsAdmin")))
            {
                contex.Result = new ForbidResult();
                return;
            }
        }

    }
}
