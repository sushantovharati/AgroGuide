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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO data)
        {
            if (ModelState.IsValid)
            {
                var user = authService.Login(data);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("UserName", user.Name);
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("Role", user.Role);

                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }

                    if (user.Role == "Farmer")
                    {
                        return RedirectToAction("Dashboard", "Farmer");
                    }
                }

                TempData["LoginMsg"] = "Invalid email or password";
            }

            return View(data);
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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
