using AgroGuide.Models;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgroGuide.Controllers
{
    public class HomeController : Controller
    {
        CropService cropService;
        ContactMessageService contactMessageService;
        MailService mailService;

        public HomeController(CropService cropService, ContactMessageService contactMessageService, MailService mailService)
        {
            this.cropService = cropService;
            this.contactMessageService = contactMessageService;
            this.mailService = mailService;
        }
        public IActionResult Index()
        {
            var crops = cropService.Get().Take(6).ToList();
            return View(crops);
        }

        public IActionResult About()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Contact(ContactMessageDTO data)
        {
            if (ModelState.IsValid)
            {
                data.CreatedAt = DateTime.Now;

                var res = contactMessageService.Create(data);

                if (res)
                {
                    mailService.SendContactMail(
                        data.FullName,
                        data.Email,
                        data.Subject,
                        data.Message
                    );

                    TempData["ContactMsg"] = "Message sent successfully";

                    return RedirectToAction("Contact");
                }
            }

            return View(data);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
