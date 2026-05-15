using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgroGuide.Controllers
{
    public class FertilizerController : Controller
    {
        FertilizerService fertilizerService;

        public FertilizerController(FertilizerService fertilizerService)
        {
            this.fertilizerService = fertilizerService;
        }
        public IActionResult Index()
        {
            var data = fertilizerService.Get();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = fertilizerService.Get();
            return View(new FertilizerDTO());
        }
        [HttpPost]
        public IActionResult Create(FertilizerDTO fertilizerDTO)
        {
            if (ModelState.IsValid)
            {
                var res = fertilizerService.Create(fertilizerDTO);
                if (res == true)
                {
                    TempData["Msg"] = "Product Created Successfully";
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Categories = fertilizerService.Get();
            return View(fertilizerDTO);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = fertilizerService.Get(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(FertilizerDTO fertilizerDTO)
        {
            if (ModelState.IsValid)
            {
                var res = fertilizerService.Update(fertilizerDTO);
                if (res == true)
                {
                    TempData["Msg"] = "Product Updated Successfully";
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Categories = fertilizerService.Get();
            return View(fertilizerDTO);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = fertilizerService.Get(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id, string Decison)
        {
            if (Decison.Equals("Yes"))
            {
                fertilizerService.Delete(id);
            }
            return RedirectToAction("Index");
        }


    }
}
