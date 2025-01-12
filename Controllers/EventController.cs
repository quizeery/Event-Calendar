using FunnyWeb.Controllers.Data;
using FunnyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace FunnyWeb.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDBContext _db;

        public EventController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<CalendarEvent> events = _db.Events.OrderBy(e => e.EventDate).ToList();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Create(string Title, string Description, DateTime EventDate, DateTime? EndDate)
		{
            if (ModelState.IsValid)
            {
                var newEvent = new CalendarEvent
                {
                    Title = Title,
                    Description = Description,
                    EventDate = EventDate,
                    EndDate = EndDate,
                    AllDay = false
                };
                
                _db.Events.Add(newEvent);
                _db.SaveChanges();

                return RedirectToAction("Index"); 
            }
            
            return View();
		}
		public IActionResult Edit(int? id)
		{
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CalendarEvent? eventFromDb = _db.Events.Find(id);
            if (eventFromDb == null)
            {
                return NotFound();
            }
			return View(eventFromDb);
		}

		[HttpPost]
		public IActionResult Edit(CalendarEvent calendarEvent)
		{
			if (ModelState.IsValid)
			{
				calendarEvent.AllDay = false;
				_db.Events.Update(calendarEvent);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(calendarEvent);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			CalendarEvent? eventFromDb = _db.Events.Find(id);
			if (eventFromDb == null)
			{
				return NotFound();
			}
			return PartialView(eventFromDb); 
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var eventFromDb = _db.Events.Find(id);
			if (eventFromDb == null)
			{
				return NotFound();
			}

			_db.Events.Remove(eventFromDb);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

        public IActionResult EventList()
        {
            var events = _db.Events.OrderBy(e => e.EventDate).ToList();
            return View(events);
        }
	}
}
