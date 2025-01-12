using FunnyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using FunnyWeb.Controllers.Data;

namespace FunnyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            var events = _db.Events
                .Select(e => new
                {
                    id = e.Id,
                    title = e.Title,
                    description = e.Description,
                    start = e.EventDate.ToString("yyyy-MM-dd'T'HH:mm:ss"),
                    end = e.EndDate.HasValue ? e.EndDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss") : null,
                    allDay = e.AllDay
                })
                .ToList();

            return Json(events);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Calendar()
        {
            var events = _db.Events.ToList();
            return View(events);
        }
    }
}
