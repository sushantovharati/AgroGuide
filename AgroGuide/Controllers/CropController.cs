using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class CropController : Controller
    {
        CropService cropService;
        CategoryService categoryService;
        SeasonService seasonService;
        SoilTypeService soilTypeService;
        WaterRequirementService waterRequirementService;

        public CropController(CropService cropService,
            CategoryService categoryService,
            SeasonService seasonService,
            SoilTypeService soilTypeService,
            WaterRequirementService waterRequirementService
            )
        {
            this.cropService = cropService;
            this.categoryService = categoryService;
            this.seasonService = seasonService;
            this.soilTypeService = soilTypeService;
            this.waterRequirementService = waterRequirementService;
        }

        public IActionResult Index()
        {
            var data = cropService.Get();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = categoryService.Get();
            ViewBag.Seasons = seasonService.Get();
            ViewBag.SoilTypes = soilTypeService.Get();
            ViewBag.WaterRequirements = waterRequirementService.Get();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CropDTO crop)
        {
            if (ModelState.IsValid)
            {
                cropService.Create(crop);

                TempData["Msg"] = "Crop Added Successfully";

                return RedirectToAction("Index");
            }

            ViewBag.Categories = categoryService.Get();
            ViewBag.Seasons = seasonService.Get();
            ViewBag.SoilTypes = soilTypeService.Get();
            ViewBag.WaterRequirements = waterRequirementService.Get();

            return View(crop);
        }

        [HttpGet]
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
        public IActionResult Update(CropDTO cropDTO)
        {
            if (ModelState.IsValid)
            {
                var res = cropService.Update(cropDTO);
                if (res == true)
                {
                    TempData["Msg"] = "Product Updated Successfully";
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Categories = categoryService.Get();
            ViewBag.Seasons = seasonService.Get();
            ViewBag.SoilTypes = soilTypeService.Get();
            ViewBag.WaterRequirements = waterRequirementService.Get();
            return View(cropDTO);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = cropService.Get(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, string Decison)
        {
            if (Decison.Equals("Yes"))
            {
                cropService.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
