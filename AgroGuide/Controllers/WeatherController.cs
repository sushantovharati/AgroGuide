using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
