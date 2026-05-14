using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class FertilizerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
