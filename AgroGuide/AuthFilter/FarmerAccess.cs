using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AgroGuide.AuthFilter
{
    public class FarmerAccess : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var role = context.HttpContext.Session.GetString("Role");

            if (role != "Farmer")
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }
    }
}
