using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class AuthController : Controller
    {
        DistrictService districtService;
        DivisionService divisionService;
        AuthService authService;

        public AuthController(DistrictService districtService, DivisionService divisionService, AuthService authService)
        {
            this.districtService = districtService;
            this.divisionService = divisionService;
            this.authService = authService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Divisions = divisionService.Get();
            ViewBag.Districts = districtService.Get();

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO data)
        {
            if (ModelState.IsValid)
            {
                authService.Register(data);

                TempData["Msg"] = "Registration successful. Please login.";

                return RedirectToAction("Login");
            }

            ViewBag.Divisions = divisionService.Get();
            ViewBag.Districts = districtService.Get();

            return View(data);
        }
    }
}
