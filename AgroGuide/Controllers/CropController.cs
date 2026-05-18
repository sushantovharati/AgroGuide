using AgroGuide.AuthFilter;
using BLL.DTOs;
using BLL.Services;
using DAL.EF.Tables;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgroGuide.Controllers
{
    public class CropController : Controller
    {
        CropService cropService;
        CategoryService categoryService;
        SeasonService seasonService;
        SoilTypeService soilTypeService;
        WaterRequirementService waterRequirementService;
        NotificationService notificationService;

        public CropController(CropService cropService,
            CategoryService categoryService,
            SeasonService seasonService,
            SoilTypeService soilTypeService,
            WaterRequirementService waterRequirementService,
            NotificationService notificationService
            )
        {
            this.cropService = cropService;
            this.categoryService = categoryService;
            this.seasonService = seasonService;
            this.soilTypeService = soilTypeService;
            this.waterRequirementService = waterRequirementService;
            this.notificationService = notificationService;
        }

        public IActionResult Index(string search)
        {
            var role = HttpContext.Session.GetString("Role");

            var data = string.IsNullOrEmpty(search) ? cropService.Get() : cropService.Search(search);

            ViewBag.Search = search;

            if (role == "Admin")
            {
                return View("AdminIndex", data);
            }

            if (role == "Farmer")
            {
                return View("Index", data);
            }

            return View(data);
        }

        [HttpGet]
        [AdminAccess]
        public IActionResult Create()
        {
            ViewBag.Categories = categoryService.Get();
            ViewBag.Seasons = seasonService.Get();
            ViewBag.SoilTypes = soilTypeService.Get();
            ViewBag.WaterRequirements = waterRequirementService.Get();

            return View();
        }

        [HttpPost]
        [AdminAccess]
        public IActionResult Create(CropDTO crop)
        {
            if (ModelState.IsValid)
            {
                var res = cropService.Create(crop);

                if (res)
                {
                    notificationService.Create(new NotificationDTO
                    {
                        Title = "New Crop Added",
                        Message = crop.CropName + " has been added",
                        Type = "Crop",
                        UserRole = "Farmer",
                        IsRead = false,
                        CreatedAt = DateTime.Now
                    });

                    TempData["CropAddMsg"] = "Crop Added Successfully";

                    return RedirectToAction("Index");
                }
            }

            ViewBag.Categories = categoryService.Get();
            ViewBag.Seasons = seasonService.Get();
            ViewBag.SoilTypes = soilTypeService.Get();
            ViewBag.WaterRequirements = waterRequirementService.Get();

            return View(crop);
        }

        [HttpGet]
        [AdminAccess]
        public IActionResult Update(int id)
        {
            var data = cropService.Get(id);
            ViewBag.Categories = categoryService.Get();
            ViewBag.Seasons = seasonService.Get();
            ViewBag.SoilTypes = soilTypeService.Get();
            ViewBag.WaterRequirements = waterRequirementService.Get();
            return View(data);
        }

        [HttpPost]
        [AdminAccess]
        public IActionResult Update(CropDTO cropDTO)
        {

            if (ModelState.IsValid)
            {
                var res = cropService.Update(cropDTO);
                if (res == true)
                {
                    notificationService.Create(new NotificationDTO
                    {
                        Title = "Crop Updated",
                        Message = cropDTO.CropName + " has been Updated",
                        Type = "Crop",
                        UserRole = "Farmer",
                        IsRead = false,
                        CreatedAt = DateTime.Now
                    });

                    TempData["Msg"] = "Product Updated Successfully";
                    return RedirectToAction("Index");
                }
                //return RedirectToAction("Index");

            }
            ViewBag.Categories = categoryService.Get();
            ViewBag.Seasons = seasonService.Get();
            ViewBag.SoilTypes = soilTypeService.Get();
            ViewBag.WaterRequirements = waterRequirementService.Get();
            return View(cropDTO);
        }

        [HttpGet]
        [AdminAccess]
        public IActionResult Delete(int id)
        {
            var data = cropService.Get(id);
            return View(data);
        }
        [HttpPost]
        [AdminAccess]
        public IActionResult Delete(int id, string Decison)
        {
            if (Decison.Equals("Yes"))
            {
                cropService.Delete(id);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = cropService.Details(id);

            if (data == null)
            {
                return RedirectToAction("Index");
            }

            return View(data);
        }

    }
}
