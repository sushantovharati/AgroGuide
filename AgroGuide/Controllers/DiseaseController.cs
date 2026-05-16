using AgroGuide.AuthFilter;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class DiseaseController : Controller
    {
        DiseaseService diseaseService;

        public DiseaseController(DiseaseService diseaseService)
        {
            this.diseaseService = diseaseService;
        }
        public IActionResult Index()
        {
            var data = diseaseService.Get();
            var role = HttpContext.Session.GetString("Role");

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
            return View(new DiseaseDTO());
        }

        [HttpPost]
        [AdminAccess]
        public IActionResult Create(DiseaseDTO disease)
        {
            if (ModelState.IsValid)
            {
                var res = diseaseService.Create(disease);
                if (res == true)
                {
                    TempData["Msg"] = "Product Created Successfully";
                    return RedirectToAction("Index");
                }

            }
            return View(disease);
        }

        [HttpGet]
        [AdminAccess]
        public IActionResult Update(int id)
        {
            var data = diseaseService.Get(id);
            return View(data);
        }

        [HttpPost]
        [AdminAccess]
        public IActionResult Update(DiseaseDTO diseaseDTO)
        {
            if (ModelState.IsValid)
            {
                var res = diseaseService.Update(diseaseDTO);
                if (res == true)
                {
                    TempData["Msg"] = "Disease Updated Successfully";
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Categories = diseaseService.Get();
            return View(diseaseDTO);
        }

        [HttpGet]
        [AdminAccess]
        public IActionResult Delete(int id)
        {
            var data = diseaseService.Get(id);
            return View(data);
        }

        [HttpPost]
        [AdminAccess]
        public IActionResult Delete(int id, string Decison)
        {
            if (Decison.Equals("Yes"))
            {
                diseaseService.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}
