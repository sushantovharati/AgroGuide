using AgroGuide.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgroGuide.Controllers
{
    public class HomeController : Controller
    {
        CropService cropService;
        public HomeController(CropService cropService)
        {
            this.cropService = cropService;
        }
        public IActionResult Index()
        {
            var crops = cropService.Get().Take(6).ToList();
            return View(crops);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
