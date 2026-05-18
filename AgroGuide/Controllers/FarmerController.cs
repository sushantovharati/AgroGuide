using AgroGuide.AuthFilter;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class FarmerController : Controller
    {
        FarmerService farmerService;
        DivisionService divisionService;
        DistrictService districtService;
        NotificationService notificationService;

        public FarmerController(FarmerService farmerService, DivisionService divisionService, 
            DistrictService districtService, NotificationService notificationService)
        {
            this.farmerService = farmerService;
            this.districtService = districtService;
            this.divisionService = divisionService;
            this.notificationService = notificationService;
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
            ViewBag.NotificationCount = notificationService.UnreadCount("Farmer");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpGet]
        [FarmerAccess]
        public IActionResult Profile()
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var data = farmerService.Get(id.Value);

            return View(data);
        }

        
        [HttpGet]
        [FarmerAccess]
        public IActionResult Update()
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var data = farmerService.Get(id.Value);

            ViewBag.Divisions = divisionService.Get();
            ViewBag.Districts = districtService.Get();

            return View(data);
        }

        [HttpPost]
        [FarmerAccess]
        public IActionResult Update(FarmerDTO farmer)
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            farmer.Id = id.Value;

            var res = farmerService.Update(farmer);

            if (res)
            {
                HttpContext.Session.SetString("UserName",
                    farmer.FirstName + " " + farmer.LastName);

                TempData["FarmerUpdateInfoMsg"] = "Profile updated successfully";

                return RedirectToAction("Profile");
            }

            ViewBag.Divisions = divisionService.Get();
            ViewBag.Districts = districtService.Get();

            return View(farmer);
        }

        [HttpGet]
        [FarmerAccess]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [FarmerAccess]
        public IActionResult ChangePassword(string password)
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var res = farmerService.ChangePassword(id.Value, password);

            if (res)
            {
                TempData["Msg"] = "Password changed successfully";
            }

            return RedirectToAction("Profile");
        }

        [HttpGet]
        [FarmerAccess]
        public IActionResult Delete()
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var data = farmerService.Get(id.Value);

            return View(data);
        }

        [HttpPost]
        [FarmerAccess]
        public IActionResult Delete(string confirm)
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var res = farmerService.Delete(id.Value);

            if (res)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Profile");
        }

        [HttpGet]
        [AdminAccess]
        public IActionResult AdminDelete(int id)
        {
            var data = farmerService.Get(id);
            return View(data);
        }

        [HttpPost]
        [AdminAccess]
        public IActionResult AdminDelete(int id, string Decision)
        {
            if (Decision.Equals("Yes"))
            {
                farmerService.Delete(id);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [FarmerAccess]
        public IActionResult Notifications()
        {
            var data = notificationService.GetByRole("Farmer");

            notificationService.MarkAllAsRead("Farmer");

            return View(data);
        }
    }
}
