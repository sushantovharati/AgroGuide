using AgroGuide.AuthFilter;
using BLL.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class FarmerController : Controller
    {
        private readonly FarmerService farmerService;

        public FarmerController(FarmerService farmerService)
        {
            this.farmerService = farmerService;
        }

        [AdminAccess]
        public IActionResult Index()
        {
            var farmer = farmerService.Get();
            return View(farmer);
        }

        [FarmerAccess]
        public IActionResult Dashboard()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpGet]
        [AdminAccess]
        public IActionResult Delete(int id)
        {
            var data = farmerService.Get(id);
            return View(data);
        }
        [HttpPost]
        [AdminAccess]
        public IActionResult Delete(int id, string Decison)
        {
            if (Decison.Equals("Yes"))
            {
                farmerService.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
