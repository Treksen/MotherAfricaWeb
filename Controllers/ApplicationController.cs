using Microsoft.AspNetCore.Mvc;
using web.Models.Application;

namespace web.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tracking(TrackingModel model)
        {
            return View(model);
        }

        public IActionResult Status(StatusModel model)
        {
            return View(model);
        }
    }
}
