using AgroGuide.AuthFilter;
using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class FarmerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [FarmerAccess]
        public IActionResult Dashboard()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
