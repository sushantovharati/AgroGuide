using AgroGuide.AuthFilter;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class AdminController : Controller
    {
        CropService cropService;
        FertilizerService fertilizerService;
        DiseaseService diseaseService;
        FarmerService farmerService;
        AdminService adminService;

        public AdminController( CropService cropService, FertilizerService fertilizerService, DiseaseService diseaseService,    
            FarmerService farmerService, AdminService adminService)
        {
            this.cropService = cropService;
            this.fertilizerService = fertilizerService;
            this.diseaseService = diseaseService;
            this.farmerService = farmerService;
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AdminAccess]
        public IActionResult Dashboard()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            ViewBag.CropCount = cropService.Count();
            ViewBag.FertilizerCount = fertilizerService.Count();
            ViewBag.DiseaseCount = diseaseService.Count();
            ViewBag.FarmerCount = farmerService.Count();
            ViewBag.RecentFarmers = farmerService.RecentFarmers();

            return View();
        }

        [AdminAccess]
        [HttpGet]
        public IActionResult Profile()
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var data = adminService.Get(id.Value);

            return View(data);
        }

        [AdminAccess]
        [HttpGet]
        public IActionResult Update()
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var data = adminService.Get(id.Value);

            return View(data);
        }

        [AdminAccess]
        [HttpPost]
        public IActionResult Update(AdminDTO admin)
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            admin.Id = id.Value;

            var res = adminService.Update(admin);

            if (res)
            {
                HttpContext.Session.SetString("UserName", admin.FirstName + " " + admin.LastName);
                TempData["AdminUpdateMsg"] = "Profile updated successfully";
            }

            return RedirectToAction("Profile");
        }


        [HttpGet]
        [AdminAccess]
        public IActionResult Delete()
        {
            var id = HttpContext.Session.GetInt32("UserId");

            if (id == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var data = adminService.Get(id.Value);

            return View(data);
        }


        [HttpPost]
        [AdminAccess]
        public IActionResult Delete(int id, string Decison)
        {
            if (Decison.Equals("Yes"))
            {
                adminService.Delete(id);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
