using AgroGuide.AuthFilter;
using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AdminAccess]
        public IActionResult Dashboard()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
