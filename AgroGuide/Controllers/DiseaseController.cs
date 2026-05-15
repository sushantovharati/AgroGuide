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
            return View(data);
        }
    }
}
