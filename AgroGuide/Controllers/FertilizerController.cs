using AgroGuide.AuthFilter;
using BLL.DTOs;
using BLL.Services;
using DAL.EF.Tables;
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
            return View(new FertilizerDTO());
        }

        [HttpPost]
        [AdminAccess]
        public IActionResult Create(FertilizerDTO fertilizer)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Errors = ModelState.Values
            //        .SelectMany(x => x.Errors)
            //        .Select(x => x.ErrorMessage)
            //        .ToList();

            //    return View(fertilizer);
            //}

            if (ModelState.IsValid)
            {
                var res = fertilizerService.Create(fertilizer);
                if (res == true)
                {
                    TempData["Msg"] = "Product Created Successfully";
                    return RedirectToAction("Index");
                }

            }
            return View(fertilizer);
        }

        [HttpGet]
        [AdminAccess]
        public IActionResult Update(int id)
        {
            var data = fertilizerService.Get(id);
            return View(data);
        }

        [HttpPost]
        [AdminAccess]
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
        [AdminAccess]
        public IActionResult Delete(int id)
        {
            var data = fertilizerService.Get(id);
            return View(data);
        }

        [HttpPost]
        [AdminAccess]
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
